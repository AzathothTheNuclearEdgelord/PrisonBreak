using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item{
    // Properties
    public string name{ protected set; get; }
    public float weight{ protected set; get; }


    // Constructor
    public Item(string name, float weight){
        this.name = name;
        this.weight = weight;
    }

    // Example of polymorphism
    //
    // public Item(float weight){
    //    name = "Unnamed";
    //    this.weight = weight;
    // }

    // Methods
}