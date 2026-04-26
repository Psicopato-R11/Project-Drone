using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraScript : MonoBehaviour
{

    public Transform car;
    public Transform firstPersonLookAt;
    public float distance = 6.4f;
    public float height = 1.4f;
    public float rotationDamping = 3.0f;
    public float heightDamping = 2.0f;
    public float zoomRatio = 0.5f;
    public float defaultFOV = 60f;

    private Vector3 rotationVector;
    private bool isFirstPerson = false;
    private bool isNormalMode = false;
    private float InitialDistance;
    private float InitialHeight;
    private Camera camera;

    [System.Serializable]
    public class CameraMode
    {
        public string name;
        public float height = 1.4f;
        public float distance = 6.4f;
        public bool isFirstPerson = false;
        public bool isNormalMode = false;
    }

    [Header("Camera Modes")]
    public CameraMode[] cameraModes;
    private int currentMode = 0;
    private const string CameraModeKey = "SelectedCameraMode";

    private SpeedBlur speedBlur;

    void Start()
    {
        camera = GetComponent<Camera>();

        currentMode = PlayerPrefs.GetInt(CameraModeKey, 0);

        speedBlur = GetComponent<SpeedBlur>();

        InitialDistance = distance;
        InitialHeight = height;

        if (cameraModes.Length > 0)
        {
            currentMode = Mathf.Clamp(currentMode, 0, cameraModes.Length - 1);
            ApplyCameraMode(cameraModes[currentMode]);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (cameraModes.Length > 0)
            {
                currentMode = (currentMode + 1) % cameraModes.Length;
                ApplyCameraMode(cameraModes[currentMode]);

                PlayerPrefs.SetInt(CameraModeKey, currentMode);
                PlayerPrefs.Save(); 
            }
        }
    }

    void ApplyCameraMode(CameraMode mode)
    {
        height = mode.height;
        distance = mode.distance;
        isFirstPerson = mode.isFirstPerson;
        isNormalMode = mode.isNormalMode;
        if (speedBlur != null)
            speedBlur.volume.enabled = !isFirstPerson;
        Debug.Log($"Modo de câmera: {mode.name}");
    }


    void LateUpdate()
    {
        if (car == null) return;

        if (isFirstPerson && firstPersonLookAt != null)
        {
            camera.nearClipPlane = 0.01f;
            camera.fieldOfView = 80f;

            transform.position = firstPersonLookAt.position;
            transform.rotation = firstPersonLookAt.rotation;
        }
        else if (isNormalMode)
        {
            distance = InitialDistance;
            height = InitialHeight;
        }
        else
        {
            camera.nearClipPlane = 0.3f;
            camera.fieldOfView = 60f;
            float wantedAngle = rotationVector.y;
            float wantedHeight = car.position.y + height;
            float myAngle = Mathf.LerpAngle(transform.eulerAngles.y, wantedAngle, rotationDamping * Time.deltaTime);
            float myHeight = Mathf.Lerp(transform.position.y, wantedHeight, heightDamping * Time.deltaTime);

            Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
            transform.position = car.position - (currentRotation * Vector3.forward * distance);

            Vector3 temp = transform.position;
            temp.y = myHeight;
            transform.position = temp;
            transform.LookAt(car);
        }
    }

    void FixedUpdate()
    {
        if (car == null) return;
        
        Vector3 localVelocity = car.InverseTransformDirection(car.GetComponent<Rigidbody>().linearVelocity);
        if (localVelocity.z < -0.1f)
        {
            Vector3 temp = rotationVector; //because temporary variables seem to be removed after a closing bracket "}" we can use the same variable name multiple times.
            temp.y = car.eulerAngles.y + 180;
            rotationVector = temp;
        }
        else
        {
            Vector3 temp = rotationVector;
            temp.y = car.eulerAngles.y;
            rotationVector = temp;
        }
        float acc = car.GetComponent<Rigidbody>().linearVelocity.magnitude;
        GetComponent<Camera>().fieldOfView = defaultFOV + acc * zoomRatio * Time.deltaTime;  //he removed * Time.deltaTime but it works better if you leave it like this.
    }
}
