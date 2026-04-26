using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public new Vector3 gravityForce = new Vector3(0, -9.81f, 0) ;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Physics.gravity = gravityForce;
            Debug.Log("A gravidade agora é: " + Physics.gravity);
        }
    }
}
