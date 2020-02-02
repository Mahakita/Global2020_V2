using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyDiskDispenser : MonoBehaviour
{
    public Receiver receiver;
    public GameObject FloppyDisk;
    //public BoxCollider FloppyDiskCollider;
    public float creationProgress;
    public float speed = 15f ;
    void Update()
    {
        if (receiver.wantsItem == false)
        {
            creationProgress += speed * Time.deltaTime;
            if (creationProgress >= 100f ) 
            {
                //FloppyDisk.GetComponent<BoxCollider>().enabled = true;               
                Instantiate(FloppyDisk, transform.position + new Vector3(0, 0, -2f), Quaternion.identity);
                creationProgress = 0f;
            }
            //if (receiver.wantsItem == true)
            //{
            //    Destroy(FloppyDisk);
            //}
        }


    }
    
}
    //bool lastWantObject
    //private void FixedUpdate()
    //{    
    //    if (receiver.wantsItem == false)
    //    {
    //        InvokeRepeating("InstantiateItem", 1f, 10f);
    //    }
    //}
        /*
        What do WebCamDevice want?
        
        We want that when the receiver is happy, he produces stuff
        when he is not happy, he does not produce stuff
        


         si receiver happy
            CreationProgress += vitesse * delta time;
            if creationProgress est a 100 ou +
                create Item
                reset progression progree
        else
            do nothing
         */

        


        // check si wants item est faux
        //if (receiver.wantsItem == true && lastWantObject == false)
        //{
        //    CancelInvoke();
        //}
        //else if (receiver.wantsItem == false  && lastWantObject == true)
        //{

        //}
        //lastWantObject = receiver.wantsItem;


    //void InstantiateItem()
    //{
    //    Instantiate(FloppyDisk,transform.position  + new Vector3(0,2,0), Quaternion.identity);
    //}
    // incrementer un float
    // si le float == 100
    // generer un item (Instanciate)
    // mettre le float a 0
