using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public string flowerName;
    public string description;

    [HideInInspector]
    public Color Colour;

    public SO_Temp so;

    public void Update() 
    {    
        flowerName = so.name;
        description = so.descriptionContent;
        Colour = so.color;
    }
}
