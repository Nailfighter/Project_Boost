using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Customize_Body : MonoBehaviour
{
    public Customization_Data color_data;
    public Material[] color;
    Renderer rend;
    void Update()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = color[color_data.color_code_body];
    }

   
}
