using UnityEngine;

//Different ways to get a popup - Loade from Addressables/Resources, instantiate from prefabs etc.
public abstract class APopupProvider : ScriptableObject
{
    public abstract UniTask<BasePopupView> LoadPopupAsync();
}