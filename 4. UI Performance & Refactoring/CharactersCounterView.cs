using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

public class CharactersCounterView : MonoBehaviour
{
    //Why should we GetComponent smth if it's can be easily and obviously passed as a reference
    [SerializeField]
    private Text text;
    
    [SerializeField]
    private float secondsToUpdate = 0.5f;
    
    //I strongly believe that some counter shouldn't have references to all entities, so assume we have some kind of 
    //CharactersManager which holds all Character references and is passed via some DI (let's say Zenject). 
    //It increases readability and stability of the architecture due to responsibility separation.
    private CharactersManager _charactersManager;

    [Inject]
    private void Construct(CharactersManager charactersManager)
    {
        _charactersManager = charactersManager;
    }
    
    private void Awake()
    {
        UpdateCharactersCounterAsync();
    }

    //Let's use async UniTask to control how often we update our counter. It will increase performance
    private async UniTask UpdateCharactersCounterAsync()
    {
        while (true)
        {
            float totalValue = 0f; 
            //Let's assume GetCurrentCharacters returns List<Character> but not List<Transform> to avoid unnecessary GetComponent and increase performance
            List<Character> characters = _charactersManager.GetCurrentCharacters();
            foreach (var character in characters)
            {
                totalValue += character.Value;
            }
            UpdateView(characters.Count, totalValue);
            await UniTask.WaitForSeconds(secondsToUpdate);
        }
    }

    public void UpdateView(float charactersCount, float totalCharactersValue)
    {
        string newText = string.Format(
            "Characters: {0} Avg value: {1}",
            charactersCount,
            //You should do totalCharactersValue / charactersCount
            //but NOT charactersCount / totalCharactersValue
            charactersCount > 0 ? totalCharactersValue / charactersCount : 0
        );
        text.text = newText;
        Debug.Log(newText);
    }
}