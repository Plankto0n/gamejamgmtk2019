using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{

    public GameManager GameManager;
    
    public Button BtnStartGame;
    public Button BtnQuit;
    public Button BtnCredits;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        BtnStartGame.onClick.AddListener(ClickStartGame);
        BtnQuit.onClick.AddListener(QuitApp);
        BtnCredits.onClick.AddListener(ClickCredits);
    }

    
    private void ClickStartGame()
    {
        GameManager.SetGameState(GameManager.GameStates.Intro);
    }

    private void QuitApp()
    {
        Application.Quit();
    }

    private void ClickCredits()
    {
        GameManager.SetGameState(GameManager.GameStates.Credits);
    }
}
