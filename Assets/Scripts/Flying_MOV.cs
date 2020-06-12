using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class Flying_MOV : MonoBehaviour
{
    [SerializeField] Rigidbody roc_rg;
    [Header("Camera")]
    [SerializeField] Transform M_camera;
    [SerializeField] Vector3 offset = new Vector3();
    public int waittime = 1;
    [Range(100f, 200f)]
    [SerializeField] float side_thrust = 100f;
    [Range(1000f, 2000f)]
    [SerializeField] float main_thrust = 100f;
    [Header("Audio")]
    public AudioClip boom;
    public AudioClip finish;
    public AudioClip thrust;
    public AudioSource Thrust_audiosource;
    public AudioSource Impact_audiosource;
    [Header("Particle System")]
    public ParticleSystem engine_thrust;
    public ParticleSystem expoltion;
    public ParticleSystem confetti;

    public enum Game_state { Main_Menu,Hit,Playing,Finish}
    public Game_state state = Game_state.Main_Menu;
    private void Start()
    {
        state = Game_state.Playing;
        M_camera = FindObjectOfType<Camera>().transform;

    }
    void Update()
    {
        if(state==Game_state.Playing)
        {
            Rotation();
            Thrust();
            Poss_Restric();
        }
        if (state != Game_state.Playing)
        {
            Thrust_audiosource.Stop();
            engine_thrust.Stop();
        }
        if (state == Game_state.Finish)
        {
            roc_rg.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    void LateUpdate()
    {
        M_camera.transform.position = new Vector3(transform.position.x, offset.y,offset.z);
    }



    private void Poss_Restric()
    {
        roc_rg.constraints = RigidbodyConstraints.FreezePositionZ;
        roc_rg.constraints = RigidbodyConstraints.FreezeRotationX;
        roc_rg.constraints = RigidbodyConstraints.FreezeRotationY;
    }

    private void Rotation()
    {
        roc_rg.angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * side_thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * side_thrust * Time.deltaTime);
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            roc_rg.AddRelativeForce(Vector3.up * main_thrust*Time.deltaTime);
            engine_thrust.Play();
            if (!Thrust_audiosource.isPlaying)
            {
                Thrust_audiosource.PlayOneShot(thrust);
            }
            
            
        }
        else 
        {
            Thrust_audiosource.Stop();
            engine_thrust.Stop();
        }


    }


}

