using UnityEngine;
using System.Collections;

public class Customization_Booster : MonoBehaviour
{
    public Material[] color;
    Renderer rend;
    public int color_code_booster = 0;
    public int color_code_body = 0;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            change_color();
        }
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = color[color_code_booster];
    
    }
    

    public void change_color()
    {
        color_code_booster++;
        if (color_code_booster >= 4)
        {
            color_code_booster = 0;
        }
    }
}
