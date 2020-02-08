using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PickupObjs : MonoBehaviour
{

    public float objDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject indicCross;
    public TMP_Text newText;
    //public AudioSource doorSound;

    public GameObject pickedObj;
    public GameObject newObj;
    public GameObject fakeObj;
    private bool pickedUp;

    private void Start()
    {
        pickedUp = false;
    }
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
        if (Input.GetButtonDown("Drop"))
        {
            DropObj();
        }

        if (objDistance <= 2 && pickedUp == false)
        {
            indicCross.SetActive(true);
            newText.SetText("Pick Up");
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
                if (pickedUp == false)
                {
                    PickUp();
                }

                if (pickedUp == true)
                {
                    DropObj();
                    PickUp();
                }
            }
        }

    }

    void PickUp()
    {
        newText.SetText(" ");
        pickedUp = true;
        this.GetComponent<BoxCollider>().enabled = false;
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
        fakeObj.SetActive(false);
        newObj.SetActive(true);
    }

    void DropObj()
    {
        if (pickedUp == false)
        {
            return;
        }

        pickedObj.transform.position = new Vector3(newObj.transform.position.x, newObj.transform.position.y + 2, newObj.transform.position.z);
        pickedUp = false;
        fakeObj.SetActive(true);
        newObj.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
