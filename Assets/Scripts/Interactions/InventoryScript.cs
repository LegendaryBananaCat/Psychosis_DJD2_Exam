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

    void Start()
    {
        active = false;
        notfyText.SetText(" ");
    }

    void Update()
    {
        objDistance = PlayerInteract.TargetDistance;

        if (Input.GetButtonDown("Action"))
        {
            if (active == true)
            {
                active = false;
                OpenPage.SetActive(false);
            }
        }
    }
    void OnMouseOver()
    {
        if (objDistance <= 2)
        {
            indicCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

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
            Debug.Log("Here1");
            if(active == false)
            {
                Debug.Log("Here2");
                if (objDistance <= 2)
                {
                    Debug.Log("Here3");
                    OpenPage.SetActive(true);
                    StartCoroutine(InventoryInfo());
                    active = true;
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

    IEnumerator InventoryInfo()
    {
        Debug.Log("Here4");
        notfyText.SetText("Page added to 'Diaries' in the Begining Room.");

        yield return new WaitForSeconds(1);

        notfyText.SetText(" ");
    }
}
