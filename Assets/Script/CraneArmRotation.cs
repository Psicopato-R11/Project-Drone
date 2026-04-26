using UnityEngine;

public class CraneArmRotation : MonoBehaviour
{
    public float rotationSpeed = 20f;
    public bool alternateDirection = true;

    private float direction = 1f;

    void Update()
    {
        transform.Rotate(0f , rotationSpeed * direction * Time.deltaTime, 0f);

        if (alternateDirection)
        {
            if (transform.localEulerAngles.y > 160f && transform.localEulerAngles.y < 180f)
                direction = -1f;
            else if (transform.localEulerAngles.y < 20f)
                direction = 1f;
        }
    }
}
