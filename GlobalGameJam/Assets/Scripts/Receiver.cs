using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public bool isBlocked;
    public bool wantsItem;
    public void ReceiveItem()
    {
        print("Item Received");
    }
}
