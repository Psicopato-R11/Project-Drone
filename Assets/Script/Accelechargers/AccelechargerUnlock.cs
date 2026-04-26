using UnityEngine;

public class AccelechargerUnlock : MonoBehaviour
{
    
    public enum AccelechargerType
    {
        Fog,
        Lava,
        Swamp,
        Fear,
        Water,
        Ruins,
        Storm,
        Time,
        Junk,
        Metro,
        Cosmic,
        Wind,
        Rain,
        Sky
    }

    [Header("Configuração")]
    public AccelechargerType accelecharger; 

    private string PrefKey => "Accelecharger_" + accelecharger.ToString();

    public bool Unlock()
    {
        // se já estava desbloqueado, não faz nada
        if (IsUnlocked())
            return false;

        PlayerPrefs.SetInt(PrefKey, 1);
        PlayerPrefs.Save();

        Debug.Log("Accelecharger desbloqueado: " + accelecharger);
        return true; // acabou de desbloquear
    }

    public bool IsUnlocked()
    {
        return PlayerPrefs.GetInt(PrefKey, 0) == 1;
    }
}
