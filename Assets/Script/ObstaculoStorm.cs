using System.Collections;
using UnityEngine;

public class ElectricObstacleSimple : MonoBehaviour
{
    public float debuffDuration = 3f;  // quanto tempo o carro fica desligado
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entrou no trigger: " + other.name); // debug pra confirmar detecção
        StormAccelecharger flag = other.GetComponentInParent<StormAccelecharger>();
        if (!flag.isActive)
        {
                if (!triggered && other.CompareTag("Player"))
                {
                    triggered = true;
                    Debug.Log("Player detectado, aplicando debuff...");

                    CarDebuffHandler debuff = other.GetComponentInParent<CarDebuffHandler>();
                    if (debuff != null)
                    {
                        Debug.Log("CarDebuffHandler encontrado!");
                        debuff.ApplyDisableDebuff(debuffDuration);
                    }
                    else
                    {
                        Debug.LogWarning("Nenhum CarDebuffHandler encontrado no objeto do Player!");
                    }
                } 
        }
    }
}
