using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderDispenser : MonoBehaviour
{
    public Receiver receiver;
    public GameObject Folder;
    //public BoxCollider FolderCollider;
    public float creationProgress;
    public float speed = 15f;
    void Update()
    {
        Collider[] colliders;
        colliders = Physics.OverlapSphere(transform.position, 4f);
        //print(colliders.Length);

        if (receiver.wantsItem == false)
        {
            if (colliders.Length <= 15)
            {
                creationProgress += speed * Time.deltaTime;
                if (creationProgress >= 100f)
                {
                    //Folder.GetComponent<BoxCollider>().enabled = true;
                    Instantiate(Folder, transform.position + new Vector3(0, 0, -2f), Quaternion.identity);
                    creationProgress = 0f;
                }
            }
        }
    }
}
