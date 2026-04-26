using UnityEngine;

public class CarUnlock : MonoBehaviour
{
    public enum CarType
    {
        RD_06, RD_06_Lava, RD_08, RD_02, RD_12, Drone, Rolo_Compressor,
        RD_09, Strange_Car, RD_06_Acceleron, RD_08_Acceleron,
        RD_02_Acceleron, RD_12_Acceleron, RD_09_Acceleron, TestCar
    }

    [Header("Configuração")]
    public CarType carType;
    public bool unlockOnTrigger = true;

    [Header("Variante Acceleron")]
    public bool unlockVariant = false;

    // Garante que a string seja EXATAMENTE igual à do CarSelection
    string GetKey(CarType type) => "Car_" + type.ToString();

    private void OnTriggerEnter(Collider other)
    {
        if (!unlockOnTrigger) return;

        if (other.CompareTag("Player"))
            Unlock();
    }

    public void Unlock()
    {
        if(!IsUnlocked(carType))
        {
            PlayerPrefs.SetInt(GetKey(carType), 1);
            Debug.Log($"<color=green>Carro base desbloqueado: {carType}</color>");
        }
        
        if (unlockVariant)
        {
            HandleVariantUnlock();
        }
            

        PlayerPrefs.Save();
    }

    void HandleVariantUnlock()
    {
        // Pega o index do carro que o player selecionou no menu
        int currentCarIndex = PlayerPrefs.GetInt("carIndex", 0);

        // Converte o index atual para o tipo Enum para saber qual carro é
        CarType currentCar = (CarType)currentCarIndex;

        // Mapeia o carro atual para sua respectiva variante Acceleron
        CarType? variant = currentCar switch
        {
            CarType.RD_06 => CarType.RD_06_Acceleron,
            CarType.RD_08 => CarType.RD_08_Acceleron,
            CarType.RD_02 => CarType.RD_02_Acceleron,
            CarType.RD_12 => CarType.RD_12_Acceleron,
            CarType.RD_09 => CarType.RD_09_Acceleron,
            _ => null
        };

        if (variant != null)
        {
            string key = GetKey(variant.Value);
            PlayerPrefs.SetInt(key, 1);
            Debug.Log($"<color=cyan>Variante desbloqueada para o carro atual: {key}</color>");
        }
        else
        {
            Debug.LogWarning("O carro que você está dirigindo não tem uma variante Acceleron mapeada.");
        }
    }

    public bool IsUnlocked(CarType type)
    {
        return PlayerPrefs.GetInt(GetKey(type), 0) == 1;
    }
}