using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationToNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(agent.velocity.y) > 1.5f && controller.GetInteger("State") != 2)
        {
            controller.SetInteger("State", 2);
        }
        else if (Mathf.Abs(agent.velocity.x) + Mathf.Abs(agent.velocity.z) > 1.5f && controller.GetInteger("State") != 1)
        {
            controller.SetInteger("State", 1);
        }
        else if (controller.GetInteger("State") != 0)
        {
            controller.SetInteger("State", 0);
        }

    }
}
