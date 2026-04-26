using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuinsAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Ruins Config")]
    public float duration = 20f;
    public Color targetColor = new Color(0, 1, 1, 0.5f); 

    public int playerLayer;
    public int obstacleLayer;

    private bool used = false;
    private bool isActive = false;
    public bool IsActive => isActive;
    public Color EffectColor => targetColor;
    public float Duration => duration;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player"); 
        obstacleLayer = LayerMask.NameToLayer("Obstaculos");
    }

    public void Activate()
    {
        if (used) return;
        used = true;
        isActive = true;
        StartCoroutine(RuinsCoroutine());
    }

    IEnumerator RuinsCoroutine()
    {
        Physics.IgnoreLayerCollision(playerLayer, obstacleLayer, true);

        yield return new WaitForSeconds(duration);

        Physics.IgnoreLayerCollision(playerLayer, obstacleLayer, false);

        isActive = false;
    }
    

    public void Deactivate() { }
}