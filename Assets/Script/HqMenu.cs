using UnityEngine;

public class HqMenu : MonoBehaviour
{
    public GameObject objectMenuButton;
    public GameObject Register;

    public void MenuButton()
    {
        objectMenuButton.SetActive(false);
        Register.SetActive(true);
    }

    public void Return()
    {
        objectMenuButton.SetActive(true);
        Register.SetActive(false);
    }
}
