using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_mov : MonoBehaviour
{
    public Transform rocket;
    public Vector3 offset;
    void Update()
    {
        if (1!=1)
        {
            // Unreachable code detected
#pragma warning disable CS0162 // Unreachable code detected
            offset.x = rocket.position.x;
#pragma warning restore CS0162 // Unreachable code detected
        }


        transform.position = rocket.position + offset;

    }
}
