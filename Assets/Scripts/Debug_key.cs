﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debug_key : MonoBehaviour
{
    bool is_pause_on = false;
    void Update()
    {
        if (Debug.isDebugBuild)
        {
            Debug_keys();
            print("Debug On");
        }
    }
    private void Debug_keys()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogError("Working");
            is_pause_on = !is_pause_on;
            if (is_pause_on==true)
            {
                Time.timeScale = 0f;
            }
            else if (is_pause_on==false) 
            {
                Time.timeScale = 1f;
            }
            
        }

    }

}