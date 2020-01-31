using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public static float TargetDistance;
    public float toTarget;

    void Update()
    {
        RaycastHit rHit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rHit))
        {
            toTarget = rHit.distance;
            TargetDistance = toTarget;
        }
    }
}
