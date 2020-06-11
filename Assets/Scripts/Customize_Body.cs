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
        print(color_data.color_code_body);
        if (Input.GetKeyDown(KeyCode.X))
        {
            change_color();
        }
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = color[color_data.color_code_body];
    }

    private void change_color()
    {
        color_data.color_code_body++;
        print(color.IsFixedSize);
        if (color_data.color_code_body >= 4)
        {
            color_data.color_code_body = 0;
            
        }
    }
}
