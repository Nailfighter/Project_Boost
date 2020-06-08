using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;


public class Flying_MOV : MonoBehaviour
{
    [SerializeField] Rigidbody roc_rg;
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

    public enum Game_state { Main_Menu, Playing, Finish, Pause, collided }
    public Game_state state = Game_state.Main_Menu;

    // Update is called once per frame
    private void Start()
    {
        roc_rg = GetComponent<Rigidbody>();

    }
    void Update()
    {
        Rotation();
        Thrust();
        Poss_Restric();
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void Poss_Restric()
    {
        roc_rg.constraints = RigidbodyConstraints.FreezePositionZ;
        roc_rg.constraints = RigidbodyConstraints.FreezeRotationX;
        roc_rg.constraints = RigidbodyConstraints.FreezeRotationY;
    }

    private void Rotation()
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
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            roc_rg.AddRelativeForce(Vector3.up * main_thrust);
            engine_thrust.Play();
            if (!Thrust_audiosource.isPlaying)
            {
                Thrust_audiosource.PlayOneShot(thrust);
            }
            
            
        }
        else 
        {
            Thrust_audiosource.Stop();
            print("rrrr");
            engine_thrust.Stop();
        }


    }
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
        

    }

    private void Death_Sequence()
    {
        Debug.Log("Hell");
        GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.collided;
        expoltion.Play();
        Impact_audiosource.Stop();
        Impact_audiosource.PlayOneShot(boom);
    }

    private void Fin_Sequence()
    {
        GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.collided;
        print("playing");
        confetti.Play();
        Impact_audiosource.Stop();
        Impact_audiosource.PlayOneShot(finish);
    }
}

