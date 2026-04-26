using UnityEngine;

public class HideUI : MonoBehaviour
{
    public GameObject UI;

    private bool IsActive = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (IsActive)
            {
                UI.SetActive(false);
                IsActive = false;
            }
            else
            {
                UI.SetActive(true);
                IsActive = true;
            }
        }
    }
}
