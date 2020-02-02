using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderDispenser : MonoBehaviour
{
    public Receiver receiver;
    public GameObject Folder;
    public BoxCollider FolderCollider;
    public float creationProgress;
    public float speed = 15f;
    void Update()
    {
        if (receiver.wantsItem == false)
        {
            creationProgress += speed * Time.deltaTime;
            if (creationProgress >= 100f)
            {
                Folder.GetComponent<BoxCollider>().enabled = true;
                Instantiate(Folder, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
                creationProgress = 0f;
            }

        }


    }

}
