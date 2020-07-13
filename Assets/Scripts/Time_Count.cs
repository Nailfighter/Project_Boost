using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Time_Count : MonoBehaviour
{
    public TextMeshProUGUI Time_UI;
    public Customization_Data time_data;
    [SerializeField] bool is_time_counting=true;
    void Update()
    {
        if (SceneManager.GetActiveScene().name=="End")
        {
            is_time_counting = false;
        }
        if (SceneManager.GetActiveScene().buildIndex==0)
        {
            time_data.time_ref = 0;
        }
        counting();
        
    }
    void counting()
    {
        if(is_time_counting)
        {
            time_data.time_ref += Time.deltaTime;
        }
        else
        {
            float min = Mathf.Round(time_data.time_ref / 60f);
            float sec=Mathf.Round(time_data.time_ref%60);
            Time_UI.text =(min+"min"+sec+"sec");
        }
    }
}
