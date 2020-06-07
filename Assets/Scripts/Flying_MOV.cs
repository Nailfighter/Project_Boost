using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Flying_MOV : MonoBehaviour
{
    public Rigidbody roc_rg;

    // Update is called once per frame
    private void Start()
    {
        roc_rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Rocket_input();
        
    }

    private void Rocket_input()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            roc_rg.AddRelativeForce(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}

