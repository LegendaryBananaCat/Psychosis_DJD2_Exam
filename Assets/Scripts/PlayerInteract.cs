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

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rHit, 500))
        {
            toTarget = rHit.distance;
            TargetDistance = toTarget;
        }
    }
}
