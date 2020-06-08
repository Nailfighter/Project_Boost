using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (GetComponent<Flying_MOV>().state==Flying_MOV.Game_state.collided)
        {
            return;
        }
        switch (collision.collider.tag)
        {
            case "Hell":
                Debug.Log("Hell");
                GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.collided;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "Pad":
                Debug.Log("Safe");
                GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.Playing;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
   
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
