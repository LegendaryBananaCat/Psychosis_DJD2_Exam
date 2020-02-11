﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoiceControlPuzzle : MonoBehaviour
{
    public float objDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject indicCross;
    public TMP_Text newText;
    //public AudioSource doorSound;

    private bool Inputactive;

    public TMP_InputField inputF;

    public GameObject PmonologueObj;
    public TMP_Text Pmonologue;

    bool truePassW;
    bool fakePassW;
    bool wrongPassW;

    public bool doneVC1 = false;

    [SerializeField]private PlayerLook pLook;

    void Start()
    {
        PmonologueObj.SetActive(false);
        Pmonologue.text = " ";
        truePassW = false;
        fakePassW = false;
        wrongPassW = false;
        Inputactive = false;
    }

    private void Update()
    {
        objDistance = PlayerInteract.TargetDistance;
    }

    void OnMouseOver()
    {
        if(Inputactive == false)
        {
            if (objDistance <= 2)
            {
                indicCross.SetActive(true);
                actionDisplay.SetActive(true);
                actionText.SetActive(true);
                newText.SetText("Input Voice Password.");
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
                    PmonologueObj.SetActive(true);
                    Inputactive = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    pLook.enabled = false;
                    PlayerInput();
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

    public void PlayerInput()
    {
        Debug.Log("Here");
        if (inputF.text == "no" || inputF.text == "no")
        {
            truePassW = true;
            StartCoroutine(MonologueManage());
            doneVC1 = true;
        }

        else if(inputF.text == "Open sesame" || inputF.text == "Open sesame!" ||inputF.text == "You shall not pass" || inputF.text == "You shall not pass!")
        {
            fakePassW = true;
            StartCoroutine(MonologueManage());
        }

        else
        {
            fakePassW = true;
            StartCoroutine(MonologueManage());
        }
    }

    IEnumerator MonologueManage()
    {
        if(truePassW == true)
        {
            PmonologueObj.SetActive(true);
            Pmonologue.text = "Yes! That was the right one! One more down!";

            yield return new WaitForSeconds(1);

            PmonologueObj.SetActive(false);
            Pmonologue.text = " ";
            Inputactive = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pLook.enabled = true;


            Destroy(this);
        }

        else if (truePassW == true)
        {
            PmonologueObj.SetActive(true);
            Pmonologue.text = "Meh. It was worth the try!";

            yield return new WaitForSeconds(1);

            PmonologueObj.SetActive(false);
            Pmonologue.text = " ";
            Inputactive = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pLook.enabled = true;
        }

        else if (truePassW == true)
        {
            PmonologueObj.SetActive(true);
            Pmonologue.text = "Wrong one. I bet it's some cheesy line or something. Yuck!";

            yield return new WaitForSeconds(1);

            PmonologueObj.SetActive(false);
            Pmonologue.text = " ";
            Inputactive = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pLook.enabled = true;
        }
    }
}