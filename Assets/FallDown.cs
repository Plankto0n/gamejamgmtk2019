using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FallDown : MonoBehaviour
{
    bool onlyonce = false;
    private NavMeshAgent _agent;
    public Vector3 backPort;
    private GameManager _gameManager;
    private CamMovement CamController;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        CamController = GameObject.Find("CameraController").GetComponent<CamMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        _agent = col.GetComponent<NavMeshAgent>();
        if(col.gameObject)
        {
            if (!onlyonce)
            {
                onlyonce = true;
                TriggerSpecialFall();
            }
        }
    }

    void TriggerSpecialFall()
    {
        //CamController.FadeOut();
        _agent.Warp(backPort);
        _gameManager.SetUpsideDown(!_gameManager.GetUpsideDown());
        CamController.SetUpsideDown(!CamController.GetUpsideDown());
        //CamController.FadeIn();
    }
}
