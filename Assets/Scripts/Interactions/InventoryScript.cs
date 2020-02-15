using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    public float objDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject indicCross;
    public TMP_Text newText;
    public TMP_Text notfyText;

    public bool active;

    public GameObject OpenPage;
    public GameObject PageMenuObj;
    public GameObject MapObj;

    public PlayerLook pLook;
    public Button MenuButton;
    private TMP_Text BTxt;
    public Collectables CTb;

    void Start()
    {
        active = false;
        MenuButton.interactable = false;
        notfyText.SetText(" ");
        BTxt = MenuButton.GetComponentInChildren<TMP_Text>();
        BTxt.SetText("Not Found");
        CTb.enabled = false;
    }

    void Update()
    {
        objDistance = PlayerInteract.TargetDistance;
    }
    void OnMouseOver()
    {
        if (objDistance <= 2)
        {
            indicCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);


            if(this.tag == ("PageMenu"))
            {
                newText.SetText("Open Page Collection");
            }

            if (this.tag == ("Map"))
            {
                newText.SetText("Pick Up Map & Pen");
            }

            else
                newText.SetText("Pick Up Page");
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
                if (this.tag == ("PageMenu"))
                {
                    FindObjectOfType<SoundManager>().Play("Open_Book");
                    PageMenuObj.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    pLook.enabled = false;
                }

                else if (this.tag == ("Map"))
                {
                    FindObjectOfType<SoundManager>().Play("Obj_Pickup");
                    CTb.enabled = true;
                    MapObj.SetActive(false);
                }

                else
                {
                    OpenPage.SetActive(true);
                    BTxt.SetText("Open");
                    StartCoroutine(InventoryInfo());
                }
            }
        }
    }

    void OnMouseExit()
    {
        indicCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
        OpenPage.SetActive(false);
        Destroy(this);
    }

    IEnumerator InventoryInfo()
    {
        notfyText.SetText("Page added to 'Page Collection' in the Starting Room.");

        yield return new WaitForSeconds(3);

        notfyText.SetText(" ");

        MenuButton.interactable = true;
    }

    public void MenuExit()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pLook.enabled = true;
    }
}
