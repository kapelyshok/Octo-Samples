using System.Collections.Generic;
using UnityEngine;

public class PopupService : IPopupService
{
    private readonly APopupProvider _provider;

    public PopupService(APopupProvider provider)
    {
        _provider = provider;
    }

    public async UniTask ShowPopupAsync(string title, string body, List<PopupButtonData> buttons)
    {
        if (buttons == null || buttons.Count == 0 || buttons.Count > 5)
        {
            Debug.LogError("Popup must have between 1 and 5 buttons.");
            return null;
        }

        var popup = await _provider.LoadPopupAsync();

        if (popup == null)
        {
            Debug.LogError("Popup creation failed.");
            return null;
        }

        popup.Setup(title, body, buttons);
    }
}
