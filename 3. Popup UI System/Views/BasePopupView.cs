using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasePopupView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text bodyText;
    //Let's assume it's some kind of LayoutGroup
    [SerializeField] private Transform buttonsRoot;
    [SerializeField] private Button buttonPrefab;

    private readonly List<Button> _spawnedButtons = new();

    public virtual void Setup(string title, string body, List<PopupButtonData> buttons)
    {
        titleText.text = title;
        bodyText.text = body;

        ClearButtons();

        foreach (var buttonData in buttons)
        {
            //TODO Get it from an ObjectPool to boost performance
            var button = Instantiate(buttonPrefab, buttonsRoot);
            button.GetComponentInChildren<TMP_Text>().text = buttonData.Text;

            button.onClick.AddListener(() =>
            {
                buttonData.Callback?.Invoke();
                Close();
            });

            _spawnedButtons.Add(button);
        }
    }

    private void ClearButtons()
    {
        foreach (var button in _spawnedButtons)
        {
            //TODO return to an ObjectPool
            Destroy(button.gameObject);
        }

        _spawnedButtons.Clear();
    }

    public virtual void Close()
    {
        Destroy(gameObject);
    }
}
