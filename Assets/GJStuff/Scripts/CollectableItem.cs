using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{

    public GameManager.GameProgress ItemColor;

    private GameManager _gameManager;
    private AudioSource _effectPlayer;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); 
        _effectPlayer = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        _effectPlayer.Play();
        _gameManager.SetGameProgress(ItemColor);
        gameObject.SetActive(false);
    }
}
