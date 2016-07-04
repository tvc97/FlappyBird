using UnityEngine;
using System.Collections;

public class MovingPipe : MonoBehaviour {

	public float maxHeight = 2F;
	public float minHeight = -2.3F;

    public static float speed = -3F;
    bool moveup;

	// Use this for initialization
	void Start () {
        moveup = (int)Random.Range(0, 2F) == 0;
    }

    // Update is called once per frame
    void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        if (transform.position.x < -15)
            gameObject.SetActive(false);
//		transform.position = new Vector3 (transform.position.x, transform.position.y + (moveup ? 0.01F : -0.01F), transform.position.z);

		if (transform.position.y > maxHeight || transform.position.y < minHeight)
			moveup = !moveup;
    }
}
