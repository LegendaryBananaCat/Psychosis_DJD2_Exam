using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject clearButton;
    [SerializeField]
    private PlayerLook pLook;

    public bool mapOpen;

    void Start()
    {
        mapOpen = false;
    }


    void Update()
    {
        if(Input.GetButtonDown("Map") && mapOpen == false)
        {
            mapOpen = true;
            map.SetActive(true);
            clearButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pLook.enabled = false;
        }
        else if (Input.GetButtonDown("Map") && mapOpen == true)
        {
            mapOpen = false;
            map.SetActive(false);
            clearButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
            pLook.enabled = true;
        }
    }
}
