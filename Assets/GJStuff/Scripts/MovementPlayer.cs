using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementPlayer : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _marker;
    public GameObject MarkerPrefab;
    public CamMovement CamController;
    private Animator _controller;
    private Vector3 _destination;
    private AudioSource _footstepSound;
    private GameManager _gameManager;
    private bool _isWalking = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _controller = GetComponent<Animator>();
        _footstepSound = GetComponent<AudioSource>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isWalking)
            {
                RaycastHit hit;
                Vector3 mousePos = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Artefakt"))    //wenn Artefakt angeklickt wurde
                    {
                        Transform artefakt = hit.collider.transform;
                        StartCoroutine(TakeArtefakt(artefakt));
                    }
                    else if (hit.collider.CompareTag("Gate"))    //wenn Gate angeklickt wurde
                    {
                        PortGate portGate = hit.collider.GetComponent<PortGate>();
                        Vector3 exitGate = portGate.GateExit.position;
                        _agent.SetDestination(portGate.GateEntrance.position);
                        if (portGate.ChangeWorld)
                        {
                            _gameManager.SetUpsideDown(!_gameManager.GetUpsideDown());
                            CamController.SetUpsideDown(!CamController.GetUpsideDown());
                        }
                        StartCoroutine(UseGate(exitGate));
                    }
                    else     //wenn nichts besonderes angeklickt wurde
                    {
                        _destination = hit.point;
                        _agent.SetDestination(_destination);
                    }
                }
            }
            else
            {
                StopCoroutine("UseGate");
                StopCoroutine("TakeArtefakt");
                _agent.ResetPath();
                _isWalking = false;
            }
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || Mathf.Abs(_agent.velocity.sqrMagnitude) < float.Epsilon)
            {
                _isWalking = false;
                if (_footstepSound.isPlaying)
                {
                    _footstepSound.Stop();
                }
            }
        }
        else
        {
            _isWalking = true;
            if (!_footstepSound.isPlaying)
            {
                _footstepSound.Play();
            }
        }
    }

    void LateUpdate()
    {
        if (_agent.hasPath)
        {
            Vector3 targetPosition = _agent.velocity;
            Vector3 targetPoint = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            Vector3 _direction = (targetPoint - transform.position).normalized;
            Quaternion _lookRotation = Quaternion.LookRotation(_direction);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, 360);
            transform.rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * 10);
        }
    }
    
    
    
    private IEnumerator UseGate(Vector3 exitPoint)
    {
        while (Vector3.Distance(transform.position, _agent.destination) >= _agent.stoppingDistance)
        {
            yield return null;
        }
        bool warped = _agent.Warp(exitPoint);
        _isWalking = false;
    }

    private IEnumerator TakeArtefakt(Transform artefakt)
    {
        _isWalking = true;
        _agent.SetDestination(artefakt.position);
        while (Vector3.Distance(transform.position, _agent.destination) >= _agent.stoppingDistance + 0.2)
        {
            yield return null;
        }
        _agent.ResetPath();
        artefakt.GetComponent<CollectableItem>().PickUp();
        _isWalking = false;
    }
}
