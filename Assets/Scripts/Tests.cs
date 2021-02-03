using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        Item i = new Item("Key of Doom", 30.0f);
        print("Item name is: \"" + i.name + "\" and it's weight is: " + i.weight);
    }
}
