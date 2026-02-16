using System;

public interface IGameplayEntity
{
    public event Action<IGameplayEntity> OnActivated;
    public event Action<IGameplayEntity> OnDeactivated;
    public event Action<IGameplayEntity> OnDestroyed;

    public bool IsActive { get; }
}