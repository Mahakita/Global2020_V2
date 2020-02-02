using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDispenser : MonoBehaviour
{
    public Receiver receiver;
    public GameObject Book;
    public BoxCollider BookBoxCollider;
    public float creationProgress;
    public float speed = 10f;
    void Update()
    {
        if (receiver.wantsItem == false)
        {
            creationProgress += speed * Time.deltaTime;
            if (creationProgress >= 100f)
            {
                Book.GetComponent<BoxCollider>().enabled = true;
                Instantiate(Book, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
                creationProgress = 0f;
            }

        }


    }

}