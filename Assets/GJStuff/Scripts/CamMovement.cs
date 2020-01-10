using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CamMovement : MonoBehaviour
{
    public GameObject Center;
    public GameObject CenterUpD;
    public GameObject[] GOsStd;
    public GameObject[] GOsUpD;
    public float TransitionSpeed;
    public LevelObjects LevelObjects;

    private int _currentPointIndex;
    private Camera _camera;
    private Vector3[] _camPositionsStd;
    private Quaternion[] _camRotationStd;
    private Vector3[] _camPositionsUpDown;
    private Quaternion[] _camRotationUpDown;
    private float _counter;
    private bool _action;
    private float _distance;
    private bool _upsideDown = false;

    //FaderComps
    public Image fader;
    public Color trans;
    public Color block;
    
    public void FadeIn()
    {
        StartCoroutine(Timer());
        fader.color = Color.Lerp(block, trans, _counter);
        fader.raycastTarget = false;
    }
    public void FadeOut()
    {
        StartCoroutine(Timer());
        fader.color = Color.Lerp(trans, block, _counter);
        fader.raycastTarget = true;
    }
    private void Awake()
    {
        _camPositionsStd = new Vector3[GOsStd.Length];
        _camRotationStd = new Quaternion[GOsStd.Length];
        _camPositionsUpDown = new Vector3[GOsUpD.Length];
        _camRotationUpDown = new Quaternion[GOsUpD.Length];
        SetUp();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        //_camera.transform.position = _camPositionsStd[0];
        //CamMove(0);
    }


    private IEnumerator Timer()
    {
        while (_counter <= 1)
        {
            _counter += Time.deltaTime * TransitionSpeed;
            yield return null;
        }
    }

    private IEnumerator CamMove(int endPointIndex)
    {
        _counter = 0;
        StartCoroutine(Timer());
        if (_upsideDown)
        {
            while (_camera.transform.position != _camPositionsUpDown[endPointIndex])
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, _camPositionsUpDown[endPointIndex], _counter);
                _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, _camRotationUpDown[endPointIndex], _counter);
                yield return null;
            }
        }
        else
        {
            while (_camera.transform.position != _camPositionsStd[endPointIndex])
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, _camPositionsStd[endPointIndex], _counter);
                _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, _camRotationStd[endPointIndex], _counter);
                yield return null;
            }
        }
        
        _action = false;
    }
    
    
    private void SetUp()
    {
        int GOStdCount = 0;
        foreach (GameObject GOStd in GOsStd)
        {
            _camPositionsStd[GOStdCount] = GOStd.transform.position;
            _camRotationStd[GOStdCount] = GOStd.transform.rotation;
            GOStdCount++;
        }
        
        int GOUpDCount = 0;
        foreach (GameObject GOUpD in GOsUpD)
        {
            _camPositionsUpDown[GOUpDCount] = GOUpD.transform.position;
            _camRotationUpDown[GOUpDCount] = GOUpD.transform.rotation;
            GOUpDCount++;
        }
    }


    public void Grau()
    {
        if (!_action)
        {
            _action = true;
            _counter = 0;
            StartCoroutine(CamMove(0));
            LevelObjects.SetLight(GameManager.GameProgress.Grey, true);
            LevelObjects.SetLight(GameManager.GameProgress.Orange, false);
            LevelObjects.SetLight(GameManager.GameProgress.Blue, false);
            LevelObjects.SetLight(GameManager.GameProgress.Yellow, false);
            LevelObjects.SetLight(GameManager.GameProgress.Green, false);
        }
    }
    
    public void Orange()
    {
        if (!_action)
        {
            _action = true;
            _counter = 0;
            StartCoroutine(CamMove(1));
            LevelObjects.SetLight(GameManager.GameProgress.Grey, false);
            LevelObjects.SetLight(GameManager.GameProgress.Orange, true);
            LevelObjects.SetLight(GameManager.GameProgress.Blue, false);
            LevelObjects.SetLight(GameManager.GameProgress.Yellow, false);
            LevelObjects.SetLight(GameManager.GameProgress.Green, false);
        }
    }
    
    public void Blau()
    {
        if (!_action)
        {
            _action = true;
            _counter = 0;
            StartCoroutine(CamMove(2));
            LevelObjects.SetLight(GameManager.GameProgress.Grey, false);
            LevelObjects.SetLight(GameManager.GameProgress.Orange, false);
            LevelObjects.SetLight(GameManager.GameProgress.Blue, true);
            LevelObjects.SetLight(GameManager.GameProgress.Yellow, false);
            LevelObjects.SetLight(GameManager.GameProgress.Green, false);
        }
    }
    
    public void Gelb()
    {
        if (!_action)
        {
            _action = true;
            _counter = 0;
            StartCoroutine(CamMove(3));
            LevelObjects.SetLight(GameManager.GameProgress.Grey, false);
            LevelObjects.SetLight(GameManager.GameProgress.Orange, false);
            LevelObjects.SetLight(GameManager.GameProgress.Blue, false);
            LevelObjects.SetLight(GameManager.GameProgress.Yellow, true);
            LevelObjects.SetLight(GameManager.GameProgress.Green, false);
        }
    }
    
    public void Grun()
    {
        if (!_action)
        {
            _action = true;
            _counter = 0;
            StartCoroutine(CamMove(4));
            LevelObjects.SetLight(GameManager.GameProgress.Grey, false);
            LevelObjects.SetLight(GameManager.GameProgress.Orange, false);
            LevelObjects.SetLight(GameManager.GameProgress.Blue, false);
            LevelObjects.SetLight(GameManager.GameProgress.Yellow, false);
            LevelObjects.SetLight(GameManager.GameProgress.Green, true);
        }
    }
    
    public void Weis()
    {
        if (!_action)
        {
            _action = true;
            _counter = 0;
            StartCoroutine(CamMove(5));
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
