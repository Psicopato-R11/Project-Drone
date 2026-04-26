using UnityEngine;
using TMPro;

public class VisualSteering : MonoBehaviour
{
    public PrometeoCarController carController;
    public TMP_Text speedText;

    [Header("Steering Settings")]
    public float steeringMultiplier = 15f;
    public bool invertRotation = true;
    public float smoothSpeed = 12f;

    float currentRotation;
    float displayedSpeed;
    public float speedSmooth = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = carController.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (carController == null) return;

        UpdateSteering();
        UpdateDisplay();
    }

    void UpdateSteering()
    {
        float wheelAngle = !carController.isSweeper
            ? carController.frontLeftCollider.steerAngle
            : carController.rearLeftCollider.steerAngle;

        float targetRotation = wheelAngle * steeringMultiplier;

        if (invertRotation)
            targetRotation *= -1f;

        currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * smoothSpeed);

        transform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
    }

    void UpdateDisplay()
    {
        if (speedText == null || rb == null) return;

        float realSpeed = rb.velocity.magnitude * 3.6f;

        displayedSpeed = Mathf.Lerp(displayedSpeed, realSpeed, Time.deltaTime * speedSmooth);

        speedText.text = Mathf.RoundToInt(displayedSpeed).ToString("000");
    }
}