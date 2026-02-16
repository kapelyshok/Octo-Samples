using System.Collections.Generic;

/// <summary>
/// Let's build event-driven service which will do the job.
/// Let's assume we will pass it via some DI (let's say Zenject)
/// Every object will register itself inside of this service and it will keep track of all of them.
/// In this case it will be a pretty clear and robust system without any unwanted references or weird responsibilities inside other systems. Everything is clear.
/// </summary>
public class GameplayEntityRegistryServiceService : IGameplayEntityRegistryService
{
    private readonly HashSet<IGameplayEntity> _activeEntities = new();
    private readonly HashSet<IGameplayEntity> _allEntities = new();

    public void Register(IGameplayEntity entity)
    {
        if (entity == null || _allEntities.Contains(entity))
        {
            return;
        }

        _allEntities.Add(entity);

        entity.OnActivated += HandleActivated;
        entity.OnDeactivated += HandleDeactivated;
        entity.OnDestroyed += HandleDestroyed;

        if (entity.IsActive)
        {
            _activeEntities.Add(entity);
        }
    }

    public void Unregister(IGameplayEntity entity)
    {
        if (entity == null || !_allEntities.Contains(entity))
        {
            return;
        }

        entity.OnActivated -= HandleActivated;
        entity.OnDeactivated -= HandleDeactivated;
        entity.OnDestroyed -= HandleDestroyed;

        _activeEntities.Remove(entity);
        _allEntities.Remove(entity);
    }

    public IReadOnlyCollection<IGameplayEntity> GetActiveEntities()
    {
        return _activeEntities;
    }

    private void HandleActivated(IGameplayEntity entity)
    {
        _activeEntities.Add(entity);
    }

    private void HandleDeactivated(IGameplayEntity entity)
    {
        _activeEntities.Remove(entity);
    }

    private void HandleDestroyed(IGameplayEntity entity)
    {
        Unregister(entity);
    }
}