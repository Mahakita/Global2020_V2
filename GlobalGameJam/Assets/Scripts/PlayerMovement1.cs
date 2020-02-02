using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    Rigidbody player;
    public float speed = 40f;
    public float gravity = 10f;
    private Vector3 moveDirection = Vector3.zero;
    bool isOverlappingLadder;

    public Animator animator;
    
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = 0;
        if (isOverlappingLadder)
        {
            vAxis = Input.GetAxis("Vertical");
        }
        Vector3 movement = new Vector3(hAxis, vAxis, 0) * speed * Time.deltaTime;
        player.MovePosition(transform.position + movement);
        


        animator.SetFloat("hAxis", Math.Abs(hAxis));
        animator.SetFloat("vAxis", vAxis);
        animator.SetBool("isOverlappingLadder", isOverlappingLadder);

        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, (hAxis < 0 ? 180 : 0), rot.z);
        transform.eulerAngles = new Vector3(rot.x, (isOverlappingLadder ? -90:transform.eulerAngles.y ), rot.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ladder"))
        {
            isOverlappingLadder = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ladder"))
        {
            isOverlappingLadder = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
