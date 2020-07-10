using UnityEngine;
using System.Collections;

public class Menu_Rocket : MonoBehaviour
{
    [SerializeField] Rigidbody M_rocket;
    [SerializeField][Range(0,50)] int force=40;

    void Update()
    {
        thrust();
    }
    void thrust()
    {
        M_rocket.AddRelativeForce(Vector3.up * force);
        M_rocket.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
