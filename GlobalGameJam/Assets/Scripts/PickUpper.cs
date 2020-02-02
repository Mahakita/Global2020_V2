using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpper : MonoBehaviour
{
    public bool enter;
    public bool stay;
    public bool exit;

    ItemType heldItemID = ItemType.None;

    private bool holdsItem = false;
    GameObject heldItem;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders;
            colliders = Physics.OverlapSphere(transform.position, 0.25f);
                //print(colliders.Length);


            if (holdsItem)
            {
                foreach (Collider c in colliders)
                {
                    if (c.GetComponent<Receiver>())
                    {
                            //print("On veut donner lobjet au receiver");
                        // CASE 1 : Receiver wants Item -> Give Item to receiver

                        if (c.GetComponent<Receiver>().ReceiveItem(heldItemID))
                        {
                            Destroy(heldItem.gameObject);
                            holdsItem = false;
                            heldItem = null;
                            return;
                        }
                        // CASE 2 : Receiver does not want Item -> Do Nothing
                        else
                        {
                            // do nothing
                        }
                    }
                }

                // CASE 3 : No receiver found, Drop Item
                {
                        //print("wanna drop");
                    //holditem to false
                    heldItem.transform.localPosition = new Vector3(0, -0.25f, -1f);
                    print(heldItem.gameObject.name);
                    heldItem.GetComponent<Rigidbody>().useGravity = true;
                    // un-parent the item
                    heldItem.transform.parent = null;
                    holdsItem = false;

                    // reenable colision component on item
                    heldItem.GetComponent<BoxCollider>().enabled = true;
                    heldItem.GetComponent<Rigidbody>().isKinematic = false;
                    heldItem = null;

                        //print(gameObject.name + " Drop Item");
                }
            }
            else
            {
                // CASE 4 : no Item, try to pickup
                foreach (Collider c in colliders)
                {
                    if (c.GetComponent<Item>())
                    {
                        c.GetComponent<Rigidbody>().useGravity = false;
                        c.GetComponent<Rigidbody>().isKinematic = true;
                        heldItem = c.gameObject;

                            //print(c.name + " Get Item");
                        holdsItem = true;
                        //what is held?
                        heldItemID = c.GetComponent<Item>().ItemID;
                        c.transform.parent = gameObject.transform;
                        c.transform.localPosition = new Vector3(1f, 0.5f, 0);
                        c.GetComponent<BoxCollider>().enabled = false;
                        return;
                    }
                }
            }
                //print("No action taken");  
        }
    }
}
