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
    Renderer renderer;
    public Material happyMat;
    public Material wantMat;


    public void Start()
    {
        renderer = GetComponent<Renderer>();

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
            renderer.material = wantMat;
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
            // set material to happy
            renderer.material = happyMat;

            // start coroutine for wants item
            print("Starting " + Time.time + " seconds");
            coroutine = WaitAndPrint(Random.Range(TempsMin, TempsMax));
            StartCoroutine(coroutine);

            print("Coroutine started");
            print("Item Received");
            // return true
            return;
        }
        // if not wants item 
        else
        {
            //return false
            return;
        }
    }
}
