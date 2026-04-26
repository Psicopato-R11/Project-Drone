using System;
using UnityEngine;

public static class AccelechargerEvents
{
    // O evento passa (Cor, Texto)
    public static event Action<Color, string> OnStatusChanged;

    public static void TriggerStatusUpdate(Color color, string label)
    {
        OnStatusChanged?.Invoke(color, label);
    }
}