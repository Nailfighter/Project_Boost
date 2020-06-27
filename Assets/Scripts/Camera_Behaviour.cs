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
    public void Update()
    {
        if (Rocket.transform.position.y < 5f)
        {
            y_axis_mov = false;
        }
        else
        {
            y_axis_mov = true;
        }
        Camera_change();
    }

    void Camera_change()
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
