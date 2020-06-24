using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Camera_Behaviour : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] Transform Rocket;
    [SerializeField] Vector3 offset = new Vector3();
    public bool y_axis_mov;
    public void Start()
    {
    }

    void LateUpdate()
    {
        if (y_axis_mov == false)
        {
            transform.position = new Vector3(Rocket.transform.position.x, offset.y, offset.z);
        }
        if (y_axis_mov == true)
        {
            transform.position = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, offset.z);
        }
    }
}
