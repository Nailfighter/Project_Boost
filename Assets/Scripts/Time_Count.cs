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
    private bool is_time_counting;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            time_data.time_ref = 0f;
        }
    }
    void Update()
    {
        time_data.time_ref += Time.deltaTime;
        Time_UI.text = Mathf.Round(time_data.time_ref).ToString();
    }
}
