using UnityEngine;

public class DroneController : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [Space]
    [SerializeField] public float Speed;
    [SerializeField] private float MouseSensitivity;

    private float pitch = 0f;

    [System.Serializable]
    public class SpeedMode
    {
        public string name;
        public float Speed = 3f;
    }

    [Header("Modos de velocidade")]
    public SpeedMode[] ModosDeVelocidade;
    private int currentMode = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentMode = (currentMode + 1) % ModosDeVelocidade.Length;
            ApplyModosDeVelocidade(ModosDeVelocidade[currentMode]);
        }


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float upDown = 0f;
        if (Input.GetKey(KeyCode.E)) upDown = 1f;
        if (Input.GetKey(KeyCode.Q)) upDown = -1f;

        PlayerMovementInput = new Vector3(horizontal, upDown, vertical);
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 forward = PlayerCamera.forward;
        Vector3 right = PlayerCamera.right;

        // Ignora o eixo Y do forward para frente/trás plano horizontal
        forward.y = 0;
        forward.Normalize();
        right.y = 0;
        right.Normalize();

        // Movimento horizontal (X/Z) relativo à câmera
        Vector3 horizontalMovement = forward * PlayerMovementInput.z + right * PlayerMovementInput.x;

        // Movimento vertical (Y) relativo à câmera
        Vector3 verticalMovement = PlayerCamera.up * PlayerMovementInput.y;

        // Soma e aplica velocidade
        Vector3 MoveVector = (horizontalMovement + verticalMovement) * Speed;

        PlayerBody.velocity = MoveVector;
    }

    private void MovePlayerCamera()
    {
        transform.Rotate(Vector3.up * PlayerMouseInput.x * MouseSensitivity);

        pitch -= PlayerMouseInput.y * MouseSensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        PlayerCamera.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }

    void ApplyModosDeVelocidade (SpeedMode mode)
    {
        Speed = mode.Speed;
        Debug.Log($"modo de velocidade: {mode.name}");
    }
}
