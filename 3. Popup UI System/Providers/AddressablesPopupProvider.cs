using UnityEngine;

[CreateAssetMenu(menuName = "UI/Popup Providers/Addressables Provider")]
public class AddressablesPopupProvider : APopupProvider
{
    public override async UniTask<PopupView> LoadPopupAsync()
    {
        try
        {
            //TODO Finish loading through Addressables
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Exception while loading popup: {e}");
            return null;
        }
    }
}