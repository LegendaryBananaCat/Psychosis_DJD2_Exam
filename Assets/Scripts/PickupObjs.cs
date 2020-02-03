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

        if (Input.GetKeyDown("d") && pickedUp == true)
        {
            Debug.Log("Here");
            DropObj();
        }
    }

    void OnMouseOver()
    {
        if (objDistance <= 2)
        {
            Debug.Log("EEEE");
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

    void OnMouseExit()
    {
        indicCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    void PickUp()
    {
        pickedUp = true;
        this.GetComponent<BoxCollider>().enabled = false;
        newText.SetText(" ");
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
        indicCross.SetActive(false);
        fakeObj.SetActive(false);
        newObj.SetActive(true);
        //doorSound.Play();
    }

    void DropObj()
    {
        pickedUp = false;
        fakeObj.SetActive(true);
        newObj.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
        pickedObj.transform.position = newObj.transform.position;
    }
}
