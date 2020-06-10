using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Launch_pad : MonoBehaviour
{
    public void OnCollisionExit(UnityEngine.Collision collision)
    {
        collision.collider.tag = "Hell";
    }
}
