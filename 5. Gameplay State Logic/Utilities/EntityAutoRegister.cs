using UnityEngine;
using Zenject;
//We can use such small automatization utility to automatically register every entity. Or we can do it manually in every class.
public class EntityAutoRegister : MonoBehaviour
{
    private IGameplayEntity _entity;

    //Let's assume that _registry is passed via some DI (let's say Zenject once again)
    private IGameplayEntityRegistryService _registryService;

    [Inject]
    private void Construct(IGameplayEntityRegistryService registryService)
    {
        _registryService = registryService;
    }

    private void Awake()
    {
        _entity = GetComponent<IGameplayEntity>();

        _registryService.Register(_entity);
    }
}