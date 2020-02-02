using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpper : MonoBehaviour
{
    public bool enter;
    public bool stay;
    public bool exit;

    private bool holdsItem = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders;
            colliders = Physics.OverlapSphere(transform.position, 0.25f);
            print(colliders.Length);


            if (holdsItem)
            {
                foreach (Collider c in colliders)
                {
                    if (c.GetComponent<Receiver>())
                    {
                        // CASE 1 : Receiver wants Item -> Give Item to receiver
                        if (c.GetComponent<Receiver>().ReceiveItem())
                        {
                            Destroy(transform.GetChild(0).gameObject);
                            holdsItem = false;
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
                    print("wanna drop");
                    //holditem to false
                    Transform heldItem = transform.GetChild(0);
                    heldItem.transform.localPosition = new Vector3(0, -0.25f, -1f);
                    heldItem.GetComponent<Rigidbody>().useGravity = true;
                    // un-parent the item
                    heldItem.transform.parent = null;

                    holdsItem = false;

                    // reenable colision component on item
                    heldItem.GetComponent<BoxCollider>().enabled = true;
                    heldItem.GetComponent<Rigidbody>().isKinematic = false;

                    print(gameObject.name + " Drop Item");
                }
            }
            else
            {
                // no Item, try to pickup
                foreach (Collider c in colliders)
                {
                    if (c.GetComponent<Item>())
                    {
                        c.GetComponent<Rigidbody>().useGravity = false;
                        c.GetComponent<Rigidbody>().isKinematic = true;


                        print(c.name + " Get Item");
                        holdsItem = true;
                        c.transform.parent = gameObject.transform;
                        c.transform.localPosition = new Vector3(0, 0.75f, 0);
                        c.GetComponent<BoxCollider>().enabled = false;
                        return;
                    }
                }
            }
            
            

            print("No action taken");

                    
        }
       
        /*
        
        -Si on appuie sur e
            -1) on check si on a un objet
                -On check si on trigger un bot
                  -  si oui, on lui donne le shit

                  -  Si non, on drop

          -  on check si on est dans le trigger dun objet
             -   si oui, on le grab



         * */
    }
    //void OnCollisionStay(Collision collision)
    //{
    //    if (holdsItem == true && Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (collision.gameObject.CompareTag("Floor"))
    //        {
    //            //holditem to false
    //            Transform heldItem = transform.GetChild(0);
    //            heldItem.transform.localPosition = new Vector3(0, -0.25f, 1f);

    //            // un-parent the item
    //            heldItem.transform.parent = null;

    //            holdsItem = false;

    //            // reenable colision component on item
    //            heldItem.GetComponent<BoxCollider>().enabled = true;
    //            print(gameObject.name + " Drop Item");
    //        }
    //    }
    //}
}
