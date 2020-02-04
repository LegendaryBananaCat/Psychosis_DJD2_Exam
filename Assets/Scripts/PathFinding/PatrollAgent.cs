using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PatrollAgent : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;
    private int target = 0;
    public Transform playerPos;

    [SerializeField]
    private float remainingDistance = 0.5f;

    [SerializeField]
    bool noise;

    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        noise = false;

        NextPoint();
    }


    void Update()
    {
            StartPath();
    }

    void NextPoint()
    {
        if(wayPoints.Length == 0)
        {
            return;
        }

        agent.destination = wayPoints[target].position;

        target = (target + 1) % wayPoints.Length;
    }

    void StartPath()
    {
        if (!agent.pathPending && agent.remainingDistance < remainingDistance)
        {
            NextPoint();
        }

        if(noise == true)
            FollowPlayer();
    }

    void FollowPlayer()
    {
        if (playerPos == null)
        {
            return;
        }

        agent.destination = playerPos.position;
    }
}
