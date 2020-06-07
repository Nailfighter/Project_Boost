using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Flying_MOV : MonoBehaviour
{
    [SerializeField] Rigidbody roc_rg;
    [SerializeField] AudioSource audioSource;
    [Range(100f,200f)]
    [SerializeField] float side_thrust = 100f;
    [Range(10f, 100f)]
    [SerializeField] float main_thrust = 100f;

    // Update is called once per frame
    private void Start()
    {
        roc_rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Rotation();
        Thrust();
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void Rotation()
    {
        roc_rg.freezeRotation = true;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward*side_thrust*Time.deltaTime);
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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

}

