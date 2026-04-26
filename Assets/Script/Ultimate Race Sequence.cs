using UnityEngine;

public class UltimateRaceSequence : MonoBehaviour
{
    public GameManager uiManager;
    public UImessage messageUI;
    public CarSelectionManager selectionManager;
    public GameObject wall;
    public CarCameraScript cameraFocus;
    public GradualColorChange colorChange;
    public Rotate[] rotatingObjects;

    public float sequenceDuration = 3f;
    bool started;

    public void StartSequence()
    {
        if (started) return;
        started = true;

        // UI
        GameManager.Instance.ShowHUD();
        UltimateRaceManager.Instance.TimerIsActive = true;

        messageUI.ShowMessage("Vencer é o que importa.");

        CarSelectionManager manager = FindFirstObjectByType<CarSelectionManager>();
        if (manager != null && selectionManager.currentCar != null)
        {
            cameraFocus.car = manager.currentCar.transform;
            cameraFocus.firstPersonLookAt = manager.currentCar.transform.Find("FPS_Point");
        }

        if (wall != null)
        {
            wall.SetActive(false);
        }

        // efeitos visuais
        colorChange.Activate();
        foreach (var obj in rotatingObjects)
            obj.Activate();

        Invoke(nameof(EndSequence), sequenceDuration);
    }

    void EndSequence()
    {
        var controller = selectionManager.currentCar.GetComponent<PrometeoCarController>();
        if (controller != null) controller.enabled = true;
    }
}