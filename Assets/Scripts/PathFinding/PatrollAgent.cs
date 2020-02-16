using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Audio;
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
    private bool canSee;

    [SerializeField] private KeyCode runKey;

    private NavMeshAgent agent;

    public AudioSource ad;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        noise = false;
        checkUp = false;

        NextPoint();

        StartCoroutine(CheckUp());
    }


    void Update()
    {
        StartPath();

        if (Input.GetKey(runKey) || Input.GetButtonDown("Drop") || canSee)
        {
            noise = true;
        }

        else
        {
            noise = false;
        }

        setHype(noise);
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
    }

    void FollowPlayer()
    {
        if (playerPos == null)
        {
            return;
        }

        agent.destination = playerPos.position;
    }

    public void CanSee(bool canSee)
    {
        this.canSee = canSee;
    }

    public void onPlayerHidden(bool hidden)
    {
        canSee = !hidden;
    }

    public void setHype(bool hype)
    {
        if (hype == false)
        {
            agent.speed = 2;
            ad.pitch = 1;
        }

        else
        {
            agent.speed = 6;
            ad.pitch = 1.7f;
        }
    }

    private IEnumerator CheckUp()
    {
        yield return new WaitForSeconds(300);
        FindObjectOfType<SoundManager>().Play("Alarm");
        Debug.LogWarning("Checkup");
        agent.destination = roomPoint.position;
        StartCoroutine(CheckUp());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Dooropen d = collision.collider.GetComponent<Dooropen>();

        if(d != null)
        {
            d.OpenDoor();
        }

        if (collision.collider.gameObject.tag.Equals("Player"))
        {
            PlayerMov Pm = collision.collider.GetComponent<PlayerMov>();
            Pm.Lives--;
            Pm.teleport(roomPoint.position);
        }
    }
}
