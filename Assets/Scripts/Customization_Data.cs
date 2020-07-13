using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName ="Costumization_data",menuName ="Cus_data")]
public class Customization_Data : ScriptableObject
{
    public int color_code_booster = 0;
    public int color_code_body = 0;
    public float time_ref=0f;
    public bool nightmare_Mode;
    public int no_of_material;
}
