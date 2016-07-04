using UnityEngine;
using System.Collections;

public class BirdMenu : MonoBehaviour {

    float anchor, distance, v;
    public AudioClip swoo;

    // Use this for initialization
    void Start () {
        anchor = transform.position.y;
        GetComponent<AudioSource>().PlayOneShot(swoo);
    }

    // Update is called once per frame
    void Update () {
        v += 0.001F;
        distance -= v;

        if (distance <= 0.1F)
            v = -0.015F;

        transform.position = new Vector2(transform.position.x, anchor + distance);

        if(Input.GetKey("space"))
        {
            Application.LoadLevel(2);
            MovingGround.speed = -3F;
            MovingPipe.speed = -3F;
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Application.LoadLevel(2);
                MovingGround.speed = -3F;
                MovingPipe.speed = -3F;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
	}
}
