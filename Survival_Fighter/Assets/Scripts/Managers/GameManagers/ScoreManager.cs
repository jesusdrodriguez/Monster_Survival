using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int count;

    Text score;
	// Use this for initialization
	void Awake () {

        score = GetComponent<Text>();
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {

        score.text = "Kill Count: " + count;
	}
}
