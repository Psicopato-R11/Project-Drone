using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public Vector3 targetRotation;
    public float speed = 90f;

    bool Active;

    Quaternion target;

    void Start()
    {
        target = Quaternion.Euler(targetRotation);
    }
    
    void Update()
    {
        if(!Active)
        {
            float rotationX = x * Time.deltaTime;
            float rotationY = y * Time.deltaTime;
            float rotationZ = z * Time.deltaTime;

            transform.Rotate(rotationX, rotationY, rotationZ);
        }

        if (!Active) return;

        transform.localRotation = Quaternion.RotateTowards(
            transform.localRotation,
            target,
            speed * Time.deltaTime
        );


    }

    public void Activate()
    {
        Active = true;
    }

}
