using UnityEngine;

public interface IAccelecharger
{
    void Activate();
    void Deactivate();
    bool IsActive { get; }
    Color EffectColor { get; }
    float Duration { get; }
}
