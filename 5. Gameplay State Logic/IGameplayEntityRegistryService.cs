using System.Collections.Generic;

public interface IGameplayEntityRegistryService
{
    public void Register(IGameplayEntity entity);
    public void Unregister(IGameplayEntity entity);
    public IReadOnlyCollection<IGameplayEntity> GetActiveEntities();
}
