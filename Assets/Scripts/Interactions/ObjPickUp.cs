using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ObjPickUp : MonoBehaviour
{
    public float objDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject indicCross;
    public TMP_Text newText;
    //public AudioSource doorSound;

    private bool pickedUp = false;
    public bool BackDKey;
    public bool FrontDKey;
    public bool Pliers;

    public GameObject pickedObjectGroup;
    public GameObject pickedObject;
    public GameObject objPlayer;

    public GameObject DoorF;
    public GameObject DoorB;
    ExitDoors ExDF;
    ExitDoors ExDB;

    private void Start()
    {
        ExDF = DoorF.GetComponent<ExitDoors>();
        ExDB = DoorB.GetComponent<ExitDoors>();
    }

    void Update()
    {
        objDistance = PlayerInteract.TargetDistance;

        if (Input.GetButtonDown("Drop"))
        {
            DropObj();
            pickedUp = false;
        }
    }

    void OnMouseOver()
    {
        if (objDistance <= 2)
        {
            indicCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

            if (FrontDKey == true)
            {
                newText.SetText("Pick Up Front Door Key");
            }

            if (BackDKey == true)
            {
                newText.SetText("Pick Up Back Door Key");
            }

            if (Pliers == true)
            {
                newText.SetText("Pick Up Pliers");
            }
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
                if (pickedUp == false)
                {
                    PickUpObj();
                }

                if (pickedUp == true)
                {
                    DropObj();
                    PickUpObj();
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

     void PickUpObj()
     {
        pickedUp = true;
        newText.SetText(" ");
        this.GetComponent<BoxCollider>().enabled = false;
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
        pickedObject.SetActive(false);
        objPlayer.SetActive(true);

        if (FrontDKey == true)
        {
            ExDF.PuzzleD1_1 = true;
        }

        if (BackDKey == true)
        {
            ExDB.PuzzleD2_1 = true;
        }

        if (Pliers == true)
        {
            ExDB.PuzzleD2_2 = true;
        }
    }

    void DropObj()
    {
        if (pickedUp == false)
        {
            return;
        }

        pickedUp = false;
        pickedObject.SetActive(true);
        objPlayer.SetActive(false);
        if(Pliers == true)
        {
            pickedObjectGroup.transform.position = new Vector3(objPlayer.transform.position.x, 0.019f, objPlayer.transform.position.z);
        }
        else
            pickedObjectGroup.transform.position = new Vector3(objPlayer.transform.position.x, -0.0147f, objPlayer.transform.position.z);

        this.GetComponent<BoxCollider>().enabled = true;

        if (FrontDKey == true)
        {
            ExDF.PuzzleD1_1 = false;
        }

        if (BackDKey == true)
        {
            ExDB.PuzzleD2_1 = false;
        }

        if (Pliers == true)
        {
            ExDB.PuzzleD2_2 = false;
        }

        StartCoroutine(OriginPos());
    }

    IEnumerator OriginPos()
    {
        if (FrontDKey == true)
        {
            yield return new WaitForSeconds(15);

            pickedObjectGroup.transform.position = new Vector3(-7.045f, 0.681f, -22.69f);
        }

        if (BackDKey == true)
        {
            yield return new WaitForSeconds(15);

            pickedObjectGroup.transform.position = new Vector3(25.543f, -0.0147f, -7.654f);
        }

        if (Pliers == true)
        {
            yield return new WaitForSeconds(15);

            pickedObjectGroup.transform.position = new Vector3(-4.8195f, 0.1357f, -14.6125f);
        }
    }
}
