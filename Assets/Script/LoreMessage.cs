using UnityEngine;

[System.Serializable]
public class LoreMessage
{
    public string text;
    [Range(0f, 1f)]
    public float chance; // 0.1 = 10%, 0.01 = 1%
}
