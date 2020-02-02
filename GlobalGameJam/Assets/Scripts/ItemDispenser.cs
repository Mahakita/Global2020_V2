using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : MonoBehaviour
{
    // reference au script item receiver
    public Receiver receiver;
    public GameObject FloppyDisk;
    public GameObject Bot;

    private void FixedUpdate()
    {    
        if (receiver.wantsItem == false)
        {
            InvokeRepeating("InstantiateItem", 1f, 10f);
        }
    }
    void Update()
    {// check si wants item est faux
        if (receiver.wantsItem == true)
        {
            CancelInvoke();
        }
    }


    void InstantiateItem()
    {
        Instantiate(FloppyDisk,transform.position  + new Vector3(0,2,0), Quaternion.identity);
    }
    // incrementer un float
    // si le float == 100
    // generer un item (Instanciate)
    // mettre le float a 0

}
