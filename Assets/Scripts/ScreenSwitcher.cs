using UnityEngine;
using System.Collections;

public class ScreenSwitcher : MonoBehaviour {

    float start;

	// Use this for initialization
	void Start () {
        Score.hightScore = PlayerPrefs.GetInt("hightScore");
        Score.hightScore2 = Score.hightScore + 1;
	}
	
	// Update is called once per frame
	void Update () {
        start += Time.deltaTime;
        if(start > 1.5F)
        {
            if (Application.loadedLevel == 0)
            {
                Application.LoadLevel(1);
            }
        }
	}
}
