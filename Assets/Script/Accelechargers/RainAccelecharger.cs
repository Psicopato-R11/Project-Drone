using UnityEngine;
using System.Collections;

public class RainAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Rain Configs")]
    public Color effectColor = Color.yellow;
    public float duration = 50f;
    public bool isActive = false;
    
    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    private bool used = false;

    [System.Serializable]
    public class WheelData
    {
        public WheelCollider collider;

        [HideInInspector] public float baseForwardStiffness;
        [HideInInspector] public float baseSidewaysStiffness;
    }

    public WheelData[] frontWheels;
    public WheelData[] rearWheels;

    [Range(0, 1)]
    public float wetPenaltyPercent = 0.5f;

    void Start()
    {
        CacheBaseStiffness(frontWheels);
        CacheBaseStiffness(rearWheels);
    }

    void CacheBaseStiffness(WheelData[] wheels)
    {
        foreach (var wheel in wheels)
        {
            wheel.baseForwardStiffness = wheel.collider.forwardFriction.stiffness;
            wheel.baseSidewaysStiffness = wheel.collider.sidewaysFriction.stiffness;
        }
    }

    void FixedUpdate()
    {
        foreach (var wheel in frontWheels) ApplyFriction(wheel);
        foreach (var wheel in rearWheels) ApplyFriction(wheel);
    }

    public void Activate()
    {
        if (used) return;
        Debug.Log("Rain ativado");
        used = true;
        isActive = true;
        StartCoroutine(RainCoroutine());
    }

    public void Deactivate()
    {

    }

    void ApplyFriction(WheelData data)
    {
        if (data.collider == null) return;

        float targetForward = data.baseForwardStiffness;
        float targetSideways = data.baseSidewaysStiffness;

        WheelHit hit;
        if (data.collider.GetGroundHit(out hit))
        {
            if (hit.collider.CompareTag("WetTrack") && !isActive)
            {
                targetForward *= wetPenaltyPercent;
                targetSideways *= wetPenaltyPercent;
            }
        }

        WheelFrictionCurve forward = data.collider.forwardFriction;
        WheelFrictionCurve sideways = data.collider.sidewaysFriction;

        forward.stiffness = targetForward;
        sideways.stiffness = targetSideways;

        data.collider.forwardFriction = forward;
        data.collider.sidewaysFriction = sideways;
    }

    IEnumerator RainCoroutine()
    {
        isActive = true;

        yield return new WaitForSeconds(duration);

        isActive = false;
    }
}