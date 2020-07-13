using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class UI_Behaviour : MonoBehaviour
{
    [SerializeField] Customization_Data data;
    public void normal_mode()
    {
        SceneManager.LoadScene(1);
        data.nightmare_Mode = false;
        print(data.nightmare_Mode);
    }
    public void nightmare_mode()
    {
        SceneManager.LoadScene(1);
        data.nightmare_Mode = true;
        print(data.nightmare_Mode);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void next_color_body()
    {
        data.color_code_body++;
        if (data.color_code_body >= data.no_of_material)
        {
            data.color_code_body = 0;

        }
    }
    public void prev_color_body()
    {
        data.color_code_body--;
        if (data.color_code_body <= -1)
        {
            data.color_code_body = data.no_of_material-1;
        }
    }
    public void next_color_booster()
    {
        data.color_code_booster++;
        if (data.color_code_booster >= data.no_of_material)
        {
            data.color_code_booster = 0;
        }
    }
    public void prev_color_booster()
    {
        data.color_code_booster--;
        if (data.color_code_booster <= -1)
        {
            data.color_code_booster = data.no_of_material-1;
        }
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
