using UnityEngine;
using System.Collections;

public class WaterAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Water Config")]
    public float duration = 15f;
    public Color effectColor = Color.yellow;
    public bool setIsTriggerTo = true;

    private bool used = false;
    private GameObject[] Planes;
    private bool isActive = false;

    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    void Start()
    {
        Planes = GameObject.FindGameObjectsWithTag("Water");
    }

    public void Activate()
    {
        if (used) return;
        Debug.Log("Water ativado");
        used = true;
        StartCoroutine(WaterRoutine());
    }

    public void Deactivate()
    {
       
    }

    IEnumerator WaterRoutine()
    {
        foreach (GameObject water in Planes)
        {
            Collider[] colliders = water.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.isTrigger = false;
            }



            yield return new WaitForSeconds(duration);


        }

        foreach (GameObject water in Planes)
        {
            Collider[] colliders = water.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.isTrigger = true;
            }
        }



    }
}
