using UnityEngine;
using UnityEngine.SceneManagement;

public class Bazinga : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SceneManager.LoadScene ("BazingaRealm");

    }
}
