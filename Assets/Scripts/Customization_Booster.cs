using UnityEngine;
using System.Collections;

public class Customization_Booster : MonoBehaviour
{
    public Customization_Data color_data;
    public Material[] color;
    Renderer rend;
    public bool n_mode;
    public void Update()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = color[color_data.color_code_booster];
        
    
    }
    
    public void mode()
    {
        n_mode = color_data.nightmare_Mode;
    }
}
