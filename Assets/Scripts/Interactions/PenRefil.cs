using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PenRefil : MonoBehaviour
{

    public float objDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject indicCross;
    public TMP_Text newText;
    //public AudioSource doorSound;

    void Update()
    {
        objDistance = PlayerInteract.TargetDistance;

        ObjsDistance();
    }

    void OnMouseExit()
    {
        indicCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    void ObjsDistance()
    {
        if (objDistance <= 2)
        {
            indicCross.SetActive(true);
            newText.SetText("Pick Up Pen Refil.");
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }
        else
        {
            newText.SetText(" ");
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (objDistance <= 2)
            {
                Refil();
            }
        }
    }

    void Refil()
    {
        Debug.Log("Refil!!");
    }
}
