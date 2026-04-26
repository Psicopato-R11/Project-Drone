using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [Header("Gravity Config")]

    public Vector3 newGravity = new Vector3(0, -4.0f, 0);

    void Start()
    {
        Physics.gravity = newGravity;
        Debug.Log(Physics.gravity);
    }

    
}
