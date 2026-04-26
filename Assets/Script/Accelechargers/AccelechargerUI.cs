using UnityEngine;
using UnityEngine.UI;

public class AccelechargerUI : MonoBehaviour
{
    public Image icon;

    [Header("PlayerPrefs")]
    public string playerPrefsKey = "EquippedAccelecharger";
    public string equippedKey = "EquippedAccelecharger";

    [Header("Sprites (index = ID)")]
    public Sprite[] accelechargerSprites;

    [Header("Visual")]
    public Color noPowerUpColor = new Color(1, 1, 1, 0);
    public Color[] accelechargerColors;
    public Color usedColor = Color.gray;

    void Start()
    {
        UpdateIconFromPrefs();
    }

    public void UpdateIconFromPrefs()
    {
        int value = PlayerPrefs.GetInt(equippedKey, -1);

        if (value == -1)
        {
            icon.sprite = null;
            icon.color = noPowerUpColor;
            return;
        }

        if (value >= 0 && value < accelechargerSprites.Length)
        {
            icon.sprite = accelechargerSprites[value];
            icon.color = accelechargerColors[value];
        }
    }

    public void MarkAsUsed()
    {
        icon.color = usedColor;
    }
}
