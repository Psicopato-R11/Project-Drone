using UnityEngine;

public class LuzLook : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target.transform);
    }
}
