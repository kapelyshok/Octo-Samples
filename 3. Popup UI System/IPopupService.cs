using System.Collections.Generic;

public interface IPopupService
{
    public UniTask ShowPopupAsync(string title, string body, List<PopupButtonData> buttons);
    //We can also expand this with ClosePopupAsync, GetAllCurentPopups (this will require some rework towards multiple popups handling), 
    //events like OnPopupClosed or OnAllPopupsClosed
    //or any other stuff accordingly to the task
}