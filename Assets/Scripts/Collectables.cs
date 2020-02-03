﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject map;
    public PlayerLook pLook;

    private bool mapOpen;
    // Start is called before the first frame update
    void Start()
    {
        mapOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Map") && mapOpen == false)
        {
            mapOpen = true;
            map.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pLook.enabled = false;
        }
        else if (Input.GetButtonDown("Map") && mapOpen == true)
        {
            mapOpen = false;
            map.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
            pLook.enabled = true;
        }
    }
}