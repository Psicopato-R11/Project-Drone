using UnityEngine;

public class GearSpin : MonoBehaviour
{
    public GameObject gear1;
    public GameObject gear2;
    public GameObject gear3;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float rotation = speed * Time.deltaTime;

        gear1.transform.Rotate(0, 0, rotation);
        gear2.transform.Rotate(0, 0, -rotation);
        gear3.transform.Rotate(0, 0, rotation);
    }
}
