using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool PickedUp;
    public bool open;

    private void Update()
    {
        if(open == true)
        {

        }
    }

    public void ItemUsage()
    {
        //if( type == page_1)
        //{
        //    open = true;
        //}
    }
}
