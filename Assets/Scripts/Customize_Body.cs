using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Customize_Body : MonoBehaviour
{
    public Material[] color;
    Renderer rend;
    public int color_code_booster = 0;
    public int color_code_body = 0;
    void Update()
    {
        print(color_code_body);
        if (Input.GetKeyDown(KeyCode.X))
        {
            change_color();
        }
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = color[color_code_body];
    }

    private void change_color()
    {
        color_code_body++;
        print(color.IsFixedSize);
        if (color_code_body >= 4)
        {
            color_code_body = 0;
            
        }
    }
}
