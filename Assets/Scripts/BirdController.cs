using UnityEngine;
using System.Collections;
using System;

public class BirdController : MonoBehaviour {

    bool Pressed = false;

    Action<Touch> touchUp;
    Touch info;

    public AudioClip wing;
    public AudioClip die;
    public AudioClip coin;
    public AudioClip hit;
    public AudioClip swoo;

    public Sprite deadSprite;

    bool dead = false;
    bool first = true;

    float countFromDead;

	// Use this for initialization
	void Start () {
        Score.score = 0;
        Score.score2 = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(first)
        {
            first = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8F);
            GetComponent<AudioSource>().PlayOneShot(swoo);
        }
        if (!dead)
        {
            float v = GetComponent<Rigidbody2D>().velocity.y;
            float angle = 10;

            if (v >= -4)
                angle = 10;
            else
                angle = Mathf.Max(-90, 10 + (v + 4) * 7);
            transform.localRotation = Quaternion.Euler(0, 0, angle);

            CheckPoint();
        } else
        {
            countFromDead += Time.deltaTime;
            if(countFromDead > 1.0F)
            {
                Application.LoadLevel(3);
            }
        }
        if(Application.platform == RuntimePlatform.Android)
            if ((Input.GetTouch(0).phase == 0) && !dead)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8F);
                GetComponent<AudioSource>().PlayOneShot(wing);
            }
    }

    void CheckPoint()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(GameObject pipe in pipes)
        {
            if(pipe.activeSelf)
            if(pipe.transform.position.x + 1.56F < transform.position.x && pipe.transform.position.z == -0.5F)
            {
                pipe.transform.position = new Vector3(pipe.transform.position.x, pipe.transform.position.y, -0.6F);
                GetComponent<AudioSource>().PlayOneShot(coin);
                Score.up();
            }
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKey("space") && !dead)
        {
            if (!Pressed)
            {
                Pressed = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8F);
                GetComponent<AudioSource>().PlayOneShot(wing);
            }
        } else
        {
            Pressed = false;
        }

        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && !dead)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8F);
                GetComponent<AudioSource>().PlayOneShot(wing);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!dead)
        {
            dead = true;
            GetComponent<SpriteRenderer>().sprite = deadSprite;
            GetComponent<Animator>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(hit);
            GetComponent<AudioSource>().PlayOneShot(die);

            MovingPipe.speed = 0F;
            MovingGround.speed = 0F;
        }
    }

}

public static class Score
{
    public static float score = 0;
    public static float score2 = 1;
    public static float hightScore = 0;
    public static float hightScore2 = 1;

    public static void up()
    {
        score++;
        score2++;
    }

    public static int getScore()
    {
        return (int)(score == score2 - 1 ? score : 0);
    }

    public static int getHightScore()
    {
        return (int)(hightScore == hightScore2 - 1 ? hightScore : 0);
    }


}