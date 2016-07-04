using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HightScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Hight Score: " + Score.getHightScore();
	}
}
