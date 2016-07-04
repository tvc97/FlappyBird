using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour
{

    public AudioClip swoo;

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(swoo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Application.LoadLevel(1);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Application.LoadLevel(1);
            }
        }

    }
}
