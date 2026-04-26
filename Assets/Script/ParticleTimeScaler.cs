using UnityEngine;

public class ParticleTimeScaler : MonoBehaviour
{
    public ParticleSystem ps;

    void Update()
    {
        if (ps == null) return;

        var main = ps.main;

       
        main.simulationSpeed = Time.timeScale;
    }
}
