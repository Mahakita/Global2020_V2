using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public bool isBlocked;
    public bool wantsItem = false;
    public ItemType itemDesired = ItemType.None;

    private IEnumerator coroutine;
    public float TempsMin = 15f;
    public float TempsMax = 25f;
    Renderer myRenderer;
    public Material happyMat;
    public Material wantMat;

    public MeshRenderer ItemRenderer;


    public void Start()
    {
        ItemRenderer.enabled = false;
        myRenderer = GetComponent<Renderer>();

        // start coroutine for wants item
        //print("Starting " + Time.time + " seconds");

        // Start function WaitAndPrint as a coroutine.

        coroutine = WaitAndPrint(Random.Range(TempsMin, TempsMax));
        StartCoroutine(coroutine);

        //print("Coroutine started");
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //print("Coroutine ended: " + Time.time + " seconds");
        // Wants Item:
        if (wantsItem == false)
        {
            wantsItem = true;
            ItemRenderer.enabled = true;
            myRenderer.material = wantMat;
        }
    }
    //is item desired?
    //public bool isItemDesired()
    //{
    //    if (heldItem == itemDesired)
    //    {
    //        ReceiveItem();
    //    }
    //}
   
    //receive Item will return a bool
    public bool ReceiveItem(ItemType itemID)
    {
        // if wants item 
        if(wantsItem == true)
        {
            if (itemDesired == itemID)
            {
                // set want item = false
                wantsItem = false;
                ItemRenderer.enabled = false;
                // set material to happy
                myRenderer.material = happyMat;

                // start coroutine for wants item
                //print("Starting " + Time.time + " seconds");
                coroutine = WaitAndPrint(Random.Range(TempsMin, TempsMax));
                StartCoroutine(coroutine);
                //print("Coroutine started");
                //print("Item Received");

                // return true
                return true;
            }
            else
            {
                return false;
            }
            
        }
        // if not wants item 
        else
        {
            //print("I don't want your item");
            //return false
            return false;
        }
    }
}
