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

    private bool pickedUp;
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
        pickedUp = false;
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

                //if (pickedUp == true)
                //{
                //    DropObj();
                //    PickUpObj();
                //}
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
        FindObjectOfType<SoundManager>().Play("Obj_Pickup");
        pickedUp = true;
        newText.SetText(" ");
        this.GetComponent<BoxCollider>().enabled = false;
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
        pickedObject.SetActive(false);
        objPlayer.SetActive(true);

        if (FrontDKey == true)
        {
            //ExDF.PuzzleD1_1 = true;

            ExDF.keyPuzzle.PD = true;
        }

        if (BackDKey == true)
        {
            //ExDB.PuzzleD2_1 = true;
            ExDB.keyPuzzle.PD = true;
        }

        if (Pliers == true)
        {
            //ExDB.PuzzleD2_2 = true;
            ExDB.pliersPuzzle.PD = true;
        }
    }

    void DropObj()
    {
        if (pickedUp == false)
        {
            return;
        }

        FindObjectOfType<SoundManager>().Play("Obj_Drop");
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


            if (pickedUp == true)
            {
                yield return new WaitForSeconds(1);
            }
        }

        if (BackDKey == true)
        {
            yield return new WaitForSeconds(15);

            pickedObjectGroup.transform.position = new Vector3(25.543f, -0.0147f, -7.654f);

            if (pickedUp == true)
            {
                yield return new WaitForSeconds(1);
            }
        }

        if (Pliers == true)
        {
            yield return new WaitForSeconds(15);

            pickedObjectGroup.transform.position = new Vector3(-4.8195f, 0.1357f, -14.6125f);

            if (pickedUp == true)
            {
                yield return new WaitForSeconds(1);
            }
        }
    }
}
