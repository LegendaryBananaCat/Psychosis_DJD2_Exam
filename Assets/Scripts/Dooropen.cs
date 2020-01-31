using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Dooropen : MonoBehaviour
{

    public float objDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject theDoor;
    public GameObject indicCross;
    public TMP_Text newText;
    //public AudioSource doorSound;

    void Update()
    {
        objDistance = PlayerInteract.TargetDistance;
    }

    void OnMouseOver()
    {
        if(objDistance <= 2)
        {
            indicCross.SetActive(true);
            newText.SetText("Open the Door");
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
            if(objDistance <=2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                newText.SetText(" ");
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                theDoor.GetComponent<Animation>().Play("Door_Open");
                //doorSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        indicCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
