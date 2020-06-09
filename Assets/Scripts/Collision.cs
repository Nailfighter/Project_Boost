using UnityEngine;
using UnityEngine.SceneManagement;


public class Collision : MonoBehaviour
{
    [SerializeField] int waittime=1;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip boom;
    public AudioClip finish;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (GetComponent<Flying_MOV>().state == Flying_MOV.Game_state.Hit)
        {
            return;
        }
        switch (collision.collider.tag)
        {
            case "Hell":
                Debug.Log("Hell");
                GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.Hit;
                audioSource.Stop();
                audioSource.PlayOneShot(boom);
                Invoke("Return_Scene", waittime);
                break;
            case "Pad":
                Debug.Log("Safe");
                GetComponent<Flying_MOV>().state = Flying_MOV.Game_state.Hit;
                print("playing");
                audioSource.Stop();
                audioSource.PlayOneShot(finish);
                Invoke("Next_Scene", waittime);
                break;
        }

    }

    public void Next_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Return_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
