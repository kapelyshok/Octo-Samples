using System;
using UnityEngine;

public abstract class AGameplayEntityBase : MonoBehaviour, IGameplayEntity
{
    public event Action<IGameplayEntity> OnActivated;
    public event Action<IGameplayEntity> OnDeactivated;
    public event Action<IGameplayEntity> OnDestroyed;

    public bool IsActive { get; private set; }

    protected virtual void OnEnable()
    {
        IsActive = true;
        OnActivated?.Invoke(this);
    }

    protected virtual void OnDisable()
    {
        IsActive = false;
        OnDeactivated?.Invoke(this);
    }

    protected virtual void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}