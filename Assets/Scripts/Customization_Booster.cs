using UnityEngine;
using System.Collections;

public class Customization_Booster : MonoBehaviour
{
    public Customization_Data color_data;
    public Material[] color;
    Renderer rend;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            change_color();
        }
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = color[color_data.color_code_booster];
        
    
    }
    

    public void change_color()
    {
        color_data.color_code_booster++;
        if (color_data.color_code_booster >= 4)
        {
            color_data.color_code_booster = 0;
        }
    }
}
