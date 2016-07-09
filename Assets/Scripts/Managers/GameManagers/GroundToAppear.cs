using UnityEngine;
using System.Collections;

public class GroundToAppear : MonoBehaviour {

    float TimeToAppear = 30f;
    float TimeToDisappear = 60f;
    float timer;
    bool isItUp = false;

    public GameObject gameObject;

	// Use this for initialization
	void Start () {

        gameObject.SetActive(false);
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if(timer >= TimeToAppear && isItUp == false)
        {
            timer = 0f;
            gameObject.SetActive(true);
            isItUp = true;
        }

        if(timer >= TimeToDisappear && isItUp)
        {
            timer = 0f;
            gameObject.SetActive(false);
            isItUp = false;
        }

	}
}
