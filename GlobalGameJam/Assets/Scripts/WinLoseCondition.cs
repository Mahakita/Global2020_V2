using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCondition : MonoBehaviour
{
    public GameObject Camera;
    public GameObject player;
    public GameObject Bot1;
    public GameObject Bot2;
    public GameObject Bot3;
    public GameObject panelWin;
    public GameObject panelLose;
    public float AngryTimer;
    public float WinTimer;
    public float AngryTimerSpeed = 10f;
    public float WinTimerSpeed = 5f;
    void Start()
    {
        
    }
    //if all bot are angry for more that 20s(pub float) then Game Over (tryagain panel) 
    //else if timer end (Float) VICTORY (win panel)! 
    void Update()
    {
        if(Bot1.GetComponent<Receiver>().wantsItem == true)
            if (Bot2.GetComponent<Receiver>().wantsItem == true)
                if (Bot3.GetComponent<Receiver>().wantsItem == true)
                {
                    AngryTimer += AngryTimerSpeed * Time.deltaTime; 
                }
        if (AngryTimer >= 100f)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerMovement1 movement = player.GetComponent<PlayerMovement1>();
            movement.enabled = false;
            CameraFollow camera = Camera.GetComponentInChildren<CameraFollow>();
            camera.enabled = false;
            panelLose.SetActive(true);
        }
        else 
        {
            WinTimer += WinTimerSpeed * Time.deltaTime;
        }
        if (WinTimer >= 100f)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerMovement1 movement = player.GetComponent<PlayerMovement1>();
            movement.enabled = false;
            CameraFollow camera = Camera.GetComponentInChildren<CameraFollow>();
            camera.enabled = false;
            panelWin.SetActive(true);
        }
    }
}
