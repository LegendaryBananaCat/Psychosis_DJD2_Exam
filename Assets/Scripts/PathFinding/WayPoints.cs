using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPoints : MonoBehaviour
{
    public Transform[] target;
    public Transform playerPos;
    public float speed;

    private int current;

    [SerializeField] bool noise;

    private void Start()
    {
        noise = false;
    }

    void Update()
    {
        if(noise == true)
        {
            FollowPlayer();
        }
        else
            FollowPath();
    }

    void FollowPath()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }

        else
        {
            current = (current + 1) % target.Length;
        }
    }

    void FollowPlayer()
    {
        if (transform.position != playerPos.position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

        }
    }
}
