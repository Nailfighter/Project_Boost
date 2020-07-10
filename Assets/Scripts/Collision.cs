using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;

public class Collision : MonoBehaviour
{
    [SerializeField] bool is_collision_on = true;
    public Customization_Data data;
    public bool n_mode;
    public void Start()
    {
        n_mode = data.nightmare_Mode;
    
    }
    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (is_collision_on) 
        {
            if (GetComponent<Flying_MOV>().Impact_audiosource.isPlaying) { return; }
            switch (collision.collider.tag)
            {
                case "Hell":
                    Debug.Log("Dead");
                    Death_Sequence();
                    break;
                case "Pad":
                    Debug.Log("Safe");
                    Fin_Sequence();
                    break;
            }
        }
            


    }

    private void Death_Sequence()
    {
        GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.Hit;
        GetComponent<Flying_MOV>().expoltion.Play();
        GetComponent<Flying_MOV>().Impact_audiosource.Stop();
        GetComponent<Flying_MOV>().Impact_audiosource.PlayOneShot(GetComponent<Flying_MOV>().boom);
        Invoke("Scene_changer", GetComponent<Flying_MOV>().waittime);
    }

    private void Fin_Sequence()
    {
        GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.Finish;
        GetComponent<Flying_MOV>().confetti.Play();
        GetComponent<Flying_MOV>().Impact_audiosource.Stop();
        GetComponent<Flying_MOV>().Impact_audiosource.PlayOneShot(GetComponent<Flying_MOV>().finish);
        Invoke("Scene_changer", GetComponent<Flying_MOV>().waittime);
    }
    public void Scene_changer()
    {

        if (GetComponent<Flying_MOV>().state == Flying_MOV.Game_state.Finish)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if (!n_mode)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
            
        }
    }

    
}

