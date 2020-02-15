using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject inventory;
    private bool inventoryEnabled;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    private void Start()
    {
        allSlots = 9;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<InventorySlot>().page = null)
            {
                slot[i].GetComponent<InventorySlot>().empty = true;
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
            inventory.SetActive(true);
        else
            inventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Book")
        {
            GameObject pagePickedUp = other.gameObject;
            InventoryItem page = pagePickedUp.GetComponent<InventoryItem>();
            AddPage(pagePickedUp, page.ID, page.type, page.description, page.icon);
        }
    }

    void AddPage(GameObject pageObject, int pageID, string pageType, string pageDescription, Sprite pageIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if(slot[i].GetComponent<InventorySlot>().empty)
            {
                pageObject.GetComponent<InventoryItem>().PickedUp = true;

                slot[i].GetComponent<InventorySlot>().page = pageObject;
                slot[i].GetComponent<InventorySlot>().icon = pageIcon;
                slot[i].GetComponent<InventorySlot>().type = pageType;
                slot[i].GetComponent<InventorySlot>().ID = pageID;
                slot[i].GetComponent<InventorySlot>().description = pageDescription;

                pageObject.transform.parent = slot[i].transform;
                pageObject.SetActive(false);

                slot[i].GetComponent<InventorySlot>().empty = false;
            }
        }
    }
}
