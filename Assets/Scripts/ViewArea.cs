using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ViewArea : MonoBehaviour
{

    public PatrollAgent PA;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerMov Pm = other.GetComponent<PlayerMov>();
            PA.CanSee(!Pm.hidden);
            Pm.onHidden += PA.onPlayerHidden;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerMov Pm = other.GetComponent<PlayerMov>();
            PA.CanSee(false);
            Pm.onHidden -= PA.onPlayerHidden;
        }
    }
}
