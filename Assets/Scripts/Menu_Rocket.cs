using UnityEngine;
using System.Collections;

public class Menu_Rocket : MonoBehaviour
{
    [SerializeField] Rigidbody M_rocket;
    [SerializeField] float force=100;
    [SerializeField] ParticleSystem thrust_p;

    void Update()
    {
        thrust();
    }
    void thrust()
    {
        M_rocket.AddRelativeForce(Vector3.up * force*Time.deltaTime);
        M_rocket.constraints = RigidbodyConstraints.FreezeRotation;
        thrust_p.Play();
    }
}
