using System.Collections;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogError("Working");
            is_pause_on = !is_pause_on;
            if (is_pause_on == true)
            {
                Time.timeScale = 0f;
            }
            else if (is_pause_on == false)
            {
                Time.timeScale = 1f;
            }

        }
        restart_level();

    }

    void restart_level()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(5);
        }

    }
}
