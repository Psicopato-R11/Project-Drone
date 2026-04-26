using UnityEngine;
using System.Collections;

public class TimeAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Time config")]
    public Color effectColor = Color.yellow;
    public float duration = 1f;
    
    private GameObject spawnPoint;
    private Vector3 playerPosition;

    private bool used = false;
    
    private bool isActive = false;
    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    public void Activate()
    {
        if (used) return;
        Debug.Log("Time ativado");
        used = true;
        isActive = true;
        TimeActivate();
    }

    public void Deactivate()
    {
        
    }

    void Start()
    {
        spawnPoint = GameObject.FindWithTag("Respawn");
    }

    void Update()
    {
        playerPosition = transform.position;
    }

    public void TimeActivate()
    {
        spawnPoint.transform.position = playerPosition;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
        }
    } 

}
