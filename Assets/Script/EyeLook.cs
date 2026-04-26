using UnityEngine;

public class EyeLook : MonoBehaviour
{
    public Transform eyeDest;

    
    void Update()
    {
        transform.LookAt(eyeDest);
    }
}
