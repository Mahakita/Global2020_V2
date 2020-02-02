using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpper : MonoBehaviour
{
    public bool enter;
    public bool stay;
    public bool exit;

    private bool holdsItem = false;

    void OnTriggerEnter(Collider other)
    {
        if (enter)
            print(other.name + " Has Entered");
    }
    void OnTriggerStay(Collider other)
    {
        if (holdsItem != true)
        {
            if (other.GetComponent<Item>() && Input.GetKey(KeyCode.E))
            {
                print(other.name + " Get Item");
                Destroy(other.gameObject);
                holdsItem = true;
                return;
            }
            return;
        }
        if (holdsItem == true)
        {
            if (other.GetComponent<Receiver>() && Input.GetKey(KeyCode.E))
            {
                print(gameObject.name + " Drop Item");
                // if receive Item returns true
                    // remove Item

                // if receive item = false
                    // keep item
                other.GetComponent<Receiver>().ReceiveItem();
                holdsItem = false;
                return;
            }
            return;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (exit)
            print(other.name + " Has Exited");
    }

    void Update()
    {
       
    }
  

    //void Update()
    //{
    //    if (Input.GetKey("E") && isOverlap != false);
    //    {
    //        hasItem;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    //void hasItem()
    //{
    //    other.GetComponent<Item>;
    //}

    //void Update()
    //{
    //    if (currentOverlappingItem == null)
    //    {
    //        print("null");
    //    }
    //    else
    //    {
    //        print(currentOverlappingItem.name);
    //    }

    //    //Debug.Log("Is Overlapping Item = " + currentOverlappingItem == null);
    //}


    //void OnTriggerEnter(Collider col)
    //{
    //    if (currentOverlappingItem != null)
    //    {
    //        return;
    //    }

    //    currentOverlappingItem = col.GetComponent<Item>();
    //    if (currentOverlappingItem != null)
    //    {
    //        Debug.Log("On Trigger Item");
    //    }
    //}

    //void OnTriggerExit(Collider col)
    //{
    //    if (currentOverlappingItem == null)
    //    {
    //        return;
    //    }

    //    if (col == currentOverlappingItem.GetComponent<Collider>())
    //    {
    //        currentOverlappingItem = null;
    //    }
    //}
}
