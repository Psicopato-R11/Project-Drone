using UnityEngine;

[RequireComponent(typeof(Camera))]
public class IgnoreFog : MonoBehaviour
{
    void OnPreRender()
    {
        RenderSettings.fog = false;
    }

    void OnPostRender()
    {
        RenderSettings.fog = true;
    }
}