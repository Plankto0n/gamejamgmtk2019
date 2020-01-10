using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates{MainMenu, Intro, Game, Pause, Death, Credits}
    public enum GameProgress{Grey, Orange, Blue, Yellow, Green, White}

    public AudioClip[] MusicFiles;
    public LevelObjects LevelObjects;

    private bool _upsideDown;
    private GameStates _curGameState;
    private GameProgress _curGameProgress;
    private AudioSource _musicPlayer;
    
    
    
    // für Singleton
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this) 
        {
            Destroy(gameObject);
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    
    private void Start()
    {
        _curGameState = GameStates.MainMenu;
        _curGameProgress = GameProgress.Grey;
        _musicPlayer = GetComponent<AudioSource>();
        _musicPlayer.clip = MusicFiles[0];
        _musicPlayer.Play();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            LevelObjects = FindObjectOfType<LevelObjects>();
        }
    }

    public void SetGameState(GameStates state)
    {
        switch (state)
        {
            case GameStates.MainMenu:
                if (_curGameState != GameStates.MainMenu)
                {
                    _curGameState = state;
                    SceneManager.LoadScene("MainMenu");
                    _musicPlayer.Stop();
                    _musicPlayer.clip = MusicFiles[0];
                    _musicPlayer.Play();
                }
                return;
            case GameStates.Intro:
                _curGameState = state;
                SceneManager.LoadScene("Intro");
                return;
            case GameStates.Game:
                SwitchToPlayMode();
                return;
            case GameStates.Pause:
                // Pause game here
                // Activate Pause-UI here
                return;
            case GameStates.Death:
                // Death Screen
                return;
            case GameStates.Credits:
                //Shut Game down - maybe save here
                _curGameState = state;
                SceneManager.LoadScene("Credits");
                return;
        }
    }

    
    public void SetGameProgress(GameProgress progress)
    {
        switch (progress)
        {
            case GameProgress.Grey: 
                return;
            case GameProgress.Orange:
                if (_curGameProgress == GameProgress.Grey)
                {
                    _curGameProgress = progress;
                    LevelObjects.PropsStonesStd.SetActive(true);
                    LevelObjects.PropsStoneUpDown.SetActive(true);
                    LevelObjects.ArtefaktBlue.SetActive(true);
                    LevelObjects.ViewOrange.interactable = true;
                    _musicPlayer.Stop();
                    _musicPlayer.clip = MusicFiles[1];
                    _musicPlayer.Play();
                }
                return;
            case GameProgress.Blue: 
                if (_curGameProgress == GameProgress.Orange)
                {
                    _curGameProgress = progress;
                    LevelObjects.PropsGrasStd.SetActive(true);
                    LevelObjects.PropsGrasUpDown.SetActive(true);
                    LevelObjects.ArtefaktYellow.SetActive(true);
                    LevelObjects.ViewBlue.interactable = true;
                }
                return;
            case GameProgress.Yellow: 
                if (_curGameProgress == GameProgress.Blue)
                {
                    _curGameProgress = progress;
                    LevelObjects.PropsFlowersStd.SetActive(true);
                    LevelObjects.PropsFlowersUpDown.SetActive(true);
                    LevelObjects.ArtefaktGreen.SetActive(true);
                    LevelObjects.ViewYellow.interactable = true;
                    _musicPlayer.Stop();
                    _musicPlayer.clip = MusicFiles[2];
                    _musicPlayer.Play();
                }
                return;
            case GameProgress.Green: 
                if (_curGameProgress == GameProgress.Yellow)
                {
                    _curGameProgress = progress;
                    LevelObjects.PropsSaplingsStd.SetActive(true);
                    LevelObjects.PropsSaplingsUpDown.SetActive(true);
                    LevelObjects.ViewGreen.interactable = true;
                }
                return;
            case GameProgress.White: 
                if (_curGameProgress == GameProgress.Green)
                    _curGameProgress = progress;
                SceneManager.LoadScene("Outro");
                return;    
        }
    }

    
    private void SwitchToPlayMode()
    {
        if (_curGameState == GameStates.MainMenu)
        {
            SceneManager.LoadScene("Game");
        }
        else if (_curGameState == GameStates.Intro)
        {
            SceneManager.LoadScene("Game");
        }
        else if (_curGameState == GameStates.Pause)
        {
            // End Pause here
        }
        else if (_curGameState == GameStates.Death)
        {
            // Reset Player after death here
        }
    }


    public void SetUpsideDown(bool value)
    {
        _upsideDown = value;
    }
    
    public bool GetUpsideDown()
    {
        return _upsideDown;
    }
}
