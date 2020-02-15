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

    bool doorOpen = false;
    public bool door1;
    public bool door3;
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
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

            if(doorOpen == false)
                newText.SetText("Open Door");

            else
                newText.SetText("Close Door");
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
                if (doorOpen == false)
                {
                    FindObjectOfType<SoundManager>().Play("Door_Open");
                    newText.SetText(" ");
                    actionDisplay.SetActive(false);
                    actionText.SetActive(false);
                    doorOpen = true;
                    //doorSound.Play();
                    if(door1 == true)
                        theDoor.GetComponent<Animation>().Play("Door1_Open");

                    else if (door3 == true)
                        theDoor.GetComponent<Animation>().Play("Door3_Open");

                    else
                        theDoor.GetComponent<Animation>().Play("Door2_Open");
                }

                else
                {
                    FindObjectOfType<SoundManager>().Play("Door_Open");
                    newText.SetText(" ");
                    actionDisplay.SetActive(false);
                    actionText.SetActive(false);
                    doorOpen = false;
                    //doorSound.Play();
                    if (door1 == true)
                        theDoor.GetComponent<Animation>().Play("Door1_Close");

                    else if (door3 == true)
                        theDoor.GetComponent<Animation>().Play("Door3_Close");

                    else
                        theDoor.GetComponent<Animation>().Play("Door2_Close");
                }

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
