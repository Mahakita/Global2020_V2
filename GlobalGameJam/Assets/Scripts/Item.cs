using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType ItemID;

    // 0 = floppy, 1 = book, 2 = folder, 3 = cookie
}

public enum ItemType { None, Folder, Book, FloppyDisk, Cookie, Any}
