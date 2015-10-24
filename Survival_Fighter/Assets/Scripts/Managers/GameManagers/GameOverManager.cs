using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;

	// Use this for initialization
	void Awake () {

        // set up reference for animator
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(playerHealth.currentHealth <= 0)
        {
            // anim for text
            anim.SetTrigger("GameOver");
            // counter/timer for game level
            restartTimer += Time.deltaTime;

            // if it reaches restart time
            if(restartTimer >= restartDelay)
            {
                // reload the level
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
}
