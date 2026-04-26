using UnityEngine;

public class CarProfile : MonoBehaviour
{
    [Header("Info")]
    public string carName;
    public bool isSweeper;

    [Header("Camera")]
    public float cameraDistance = 6.4f;
    public float cameraHeight = 1.4f;

    [Header("Velocidade")]
    public float maxSpeed = 250f;
}