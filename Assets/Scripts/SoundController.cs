using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        AudioSource.PlayClipAtPoint(GetComponent<AudioClip>(), new Vector3(0, 0, 0));
	}
}
