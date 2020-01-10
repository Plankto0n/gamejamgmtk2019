using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private Button _backButton;
    
    // Start is called before the first frame update
    void Start()
    {
        _backButton = GetComponent<Button>();
        _backButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.SetGameState(GameManager.GameStates.MainMenu);
    }
}
