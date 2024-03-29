﻿using System;
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
    private bool is_headlight_on=false;
    [SerializeField] GameObject headlight;
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            state = Game_state.Playing;
        }
        


    }
    void Update()
    {
        Spotlight_on();
        if (state==Game_state.Playing)
        {
            Rotation();
            Thrust();
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
    
    public void Spotlight_on()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock)) 
        {
            is_headlight_on =! is_headlight_on;
            if (!is_headlight_on)
            {
                headlight.SetActive(false);
            }
            else
            {
                headlight.SetActive(true);
            }
        }
        
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

