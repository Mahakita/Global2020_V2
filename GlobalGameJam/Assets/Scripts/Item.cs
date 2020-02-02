using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType ItemID;

    // 0 = none, 1 = folder, 2 = book, 3 = floppy, 4 = cokkie, 5 = any
}

public enum ItemType { None, Folder, Book, FloppyDisk, Cookie, Any}
