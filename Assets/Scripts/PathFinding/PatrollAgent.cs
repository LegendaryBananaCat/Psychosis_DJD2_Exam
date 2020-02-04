using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PatrollAgent : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    private int target = 0;

    public Transform playerPos;
    public Transform roomPoint;

    [SerializeField] private float remainingDistance = 0.5f;

    [SerializeField] bool noise;
    [SerializeField] bool checkUp;

    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = false;

        noise = false;
        checkUp = false;

        NextPoint();
    }


    void Update()
    {
        SeePlayer();
        StartPath();

        if(noise == true)
        {
            agent.speed = 6;
        }
        else
            agent.speed = 4;
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
        {
            FollowPlayer();
        }

        if(checkUp == true)
        {
            RoomCheckup();
        }
    }

    void FollowPlayer()
    {
        if (playerPos == null)
        {
            return;
        }

        agent.destination = playerPos.position;
    }

    void RoomCheckup()
    {
        if (roomPoint == null)
        {
            return;
        }

        agent.destination = roomPoint.position;
    }

    void SeePlayer()
    {

    }
}
