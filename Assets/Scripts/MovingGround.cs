using UnityEngine;
using System.Collections;

public class MovingGround : MonoBehaviour {

    public static float speed = -3F;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        if (transform.position.x < -15)
            transform.position = new Vector3(transform.position.x + 6.6F * 5.0F, transform.position.y, -1F);
    }
}
