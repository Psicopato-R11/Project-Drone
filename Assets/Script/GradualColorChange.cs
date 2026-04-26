using UnityEngine;

public class GradualColorChange : MonoBehaviour
{
    public MeshRenderer mesh;
    [ColorUsage(true, true)] 
    public Color targetColor = Color.yellow;
    public float speed = 1f;

    Material mat;
    bool active;

    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    void Start()
    {
        mat = mesh.material; 

        mat.EnableKeyword("_EMISSION");
    }

    public void Activate()
    {
        active = true;
    }

    void Update()
    {
        if (!active) return;

        Color currentColor = mat.GetColor(EmissionColor);

        Color nextColor = Color.Lerp(
            currentColor,
            targetColor,
            Time.deltaTime * speed
        );
        mat.SetColor(EmissionColor, nextColor);
    }
}