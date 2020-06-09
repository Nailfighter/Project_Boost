using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;


public class Flying_MOV : MonoBehaviour
{
    [SerializeField] Rigidbody roc_rg;
    public bool level_up;
    [Header("Game Levers")]
    [SerializeField] int waittime = 1;
    [Range(100f, 200f)]
    [SerializeField] float side_thrust = 100f;
    [Range(10f, 100f)]
    [SerializeField] float main_thrust = 100f;
    [Header("Audio")]
    public AudioClip boom;
    public AudioClip finish;
    public AudioClip thrust;
    public AudioSource Thrust_audiosource;
    public AudioSource Impact_audiosource;
    [Header("Particle System")]
    [SerializeField] ParticleSystem engine_thrust;
    [SerializeField] ParticleSystem expoltion;
    [SerializeField] ParticleSystem confetti;

    public enum Game_state { Main_Menu, Playing, Finish, Pause,Hit}
    public Game_state state = Game_state.Main_Menu;

    private void Start()
    {
        state = Game_state.Playing;
    }

    public void Update()
    {
        if (state == Game_state.Playing)
        {
            Input_For_Rotation();
            Input_For_Thrusting();
            Poss_Restric();

            
            
        }
        if (Input.GetKey(KeyCode.R))
        {
            level_up = false;
            Scene_Changer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (state != Game_state.Playing) 
        {
            Thrust_audiosource.Stop();
            engine_thrust.Stop();
        }


    }

    private void Poss_Restric()
    {
        roc_rg.constraints = RigidbodyConstraints.FreezePositionZ;
        roc_rg.constraints = RigidbodyConstraints.FreezeRotationX;
        roc_rg.constraints = RigidbodyConstraints.FreezeRotationY;
    }//keep the rocket in right axis

    private void Input_For_Rotation()
    {
        roc_rg.freezeRotation = true;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * side_thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * side_thrust * Time.deltaTime);
        }
        roc_rg.freezeRotation = false;
    }//input for rotation and variation in physic engine

    private void Input_For_Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            roc_rg.AddRelativeForce(Vector3.up * main_thrust);
            engine_thrust.Play();
            if (!Thrust_audiosource.isPlaying)
            {
                Thrust_audiosource.PlayOneShot(thrust);
            }
            
            
        }//starts thrusting and audio
        else 
        {
            Thrust_audiosource.Stop();
            engine_thrust.Stop(); 
        }


    }//thrusing and audio
    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (Impact_audiosource.isPlaying) { return; }
        switch (collision.collider.tag)
        {
            case "Hell":
                Death_Sequence();
                break;
            case "Pad":
                Debug.Log("Safe");
                Fin_Sequence();
                break;
        }
        

    }//collision

    public void Death_Sequence()
    {
        state = Flying_MOV.Game_state.Hit;
        expoltion.Play();
        Impact_audiosource.Stop();
        Impact_audiosource.PlayOneShot(boom);
        level_up = false;
        Invoke("Scene_Changer", waittime);
    }

    public void Fin_Sequence()
    {
        if (state==Game_state.Playing)
        {
            state = Flying_MOV.Game_state.Finish;
            confetti.Play();
            Impact_audiosource.Stop();
            Impact_audiosource.PlayOneShot(finish);
            level_up = true;
            Invoke("Scene_Changer", waittime);
        }
        
    }
    public void Scene_Changer()
    {
        if (1 == 1)
        {
            return;
        }
#pragma warning disable CS0162 // Unreachable code detected
        if (level_up)
#pragma warning restore CS0162 // Unreachable code detected
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}

