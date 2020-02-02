using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public bool isBlocked;
    public bool wantsItem = false;

    private IEnumerator coroutine;
    public float TempsMin = 15f;
    public float TempsMax = 25f;
    Material m_Material;

    public void Start()
    {
        m_Material = GetComponent<Renderer>().material;

        // start coroutine for wants item
        // - After 0 seconds, prints "Starting 0.0 seconds"
        // - After 0 seconds, prints "Coroutine started"
        // - After 2 seconds, prints "Coroutine ended: 8.0 seconds"
        print("Starting " + Time.time + " seconds");

        // Start function WaitAndPrint as a coroutine.

        coroutine = WaitAndPrint(Random.Range(TempsMin, TempsMax));
        StartCoroutine(coroutine);

        print("Coroutine started");
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("Coroutine ended: " + Time.time + " seconds");
        // Wants Item:
        if (wantsItem != true)
        {
            wantsItem = true;
            m_Material.color = Color.red;
        }
    }

   
    //receive Item will return a bool
    public void ReceiveItem()
    {
        // if wants item 
        if(wantsItem != false)
        {
            // set want item = false
            wantsItem = false;
            m_Material.color = ;

        }
            // set material to happy
            // start coroutine for wants item
            // return true

        // if not wants item 
            //return false
        print("Item Received");



    }


    //coroutine
        // wait random time amount
        // wants Item= true
        // set material to desire material
}
