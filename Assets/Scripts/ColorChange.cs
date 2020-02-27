using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color altColor = Color.black;
    public Renderer rend;

    //I do not know why you need this?
    void Example()
    {   
        altColor.g = 0.9f;
        altColor.r = 0.2f;
        altColor.b = 0.1f;
        altColor.a = 1f;
    }

    void Start()
    {
        //Call Example to set all color values to zero.
        Example();
        //Get the renderer of the object so we can access the color
        rend = GetComponent<Renderer>();
        //Set the initial color (0f,0f,0f,0f)
        rend.material.color = altColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Alter the color          
            altColor.g += 0.1f;
            //Assign the changed color to the material.
            rend.material.color = altColor;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Alter the color           
            altColor.r += 0.1f;
            //Assign the changed color to the material. 
            rend.material.color = altColor;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            //Alter the color            
            altColor.b += 0.1f;
            //Assign the changed color to the material. 
            rend.material.color = altColor;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Alter the color          
            altColor.a += 0.1f;
            //Assign the changed color to the material. 
            rend.material.color = altColor;
        }
    }
}
