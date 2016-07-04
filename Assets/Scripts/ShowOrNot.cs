using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowOrNot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Score.getScore() >= Score.getHightScore())
        {
            Score.hightScore = Score.getScore();
            Score.hightScore2 = Score.getScore() + 1;
            PlayerPrefs.SetInt("hightScore", Score.getHightScore());
            GetComponent<Text>().text = "New Hight Score!!!";
        } else
        {
            GetComponent<Text>().text = "";
        }
    }
}
