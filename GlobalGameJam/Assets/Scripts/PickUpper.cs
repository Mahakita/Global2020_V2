using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpper : MonoBehaviour
{

    Item currentOverlappingItem;

    void Update()
    {
        if (currentOverlappingItem == null)
        {
            print("null");
        }
        else
        {
            print(currentOverlappingItem.name);
        }

        //Debug.Log("Is Overlapping Item = " + currentOverlappingItem == null);
    }


    void OnTriggerEnter(Collider col)
    {
        if (currentOverlappingItem != null)
        {
            return;
        }

        currentOverlappingItem = col.GetComponent<Item>();
        if (currentOverlappingItem != null)
        {
            Debug.Log("On Trigger Item");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (currentOverlappingItem == null)
        {
            return;
        }

        if (col == currentOverlappingItem.GetComponent<Collider>())
        {
            currentOverlappingItem = null;
        }

    }
}
