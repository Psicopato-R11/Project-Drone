using UnityEngine;
using System.Collections;

public class LavaAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Lava Config")]
    public Color effectColor = Color.yellow;
    public float duration = 15f;
    public bool setIsTriggerTo = true;

    private bool used = false;
    private GameObject[] Planes;

    private bool isActive = false;

    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    void Start()
    {
        Planes = GameObject.FindGameObjectsWithTag("Lava");
    }
    
    public void Activate()
    {
        if (used) return;

        used = true;
        StartCoroutine(LavaRoutine());
    }

    public void Deactivate()
    {

    }

    IEnumerator LavaRoutine()
    {
        foreach (GameObject lava in Planes)
        {
            Collider[] colliders = lava.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.isTrigger = false;
            }

            

            yield return new WaitForSeconds(duration);

            
        }
            
        foreach (GameObject lava in Planes)
        {
            Collider[] colliders = lava.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.isTrigger = true;
            }
        }
       

        
    }
}
