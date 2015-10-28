using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 200;
    public int currentHealth;    
    float sinkSpeed = 0.5f;
    int scoreValue = 1;

    //Animator anim;
    public Slider healthSlider;
    EnemyAttack enemyAttack;
    EnemyMovement enemyMovement;
    bool isSinking;
    bool isDead;

	// Use this for initialization
    void Awake() {

        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
        //anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update() {

        if(isSinking)
        {
            transform.Translate(-Vector2.up * sinkSpeed * Time.deltaTime);
        }
	}

    // might require vector2 hitpoint for bullet impacts
    //
    public void TakeDamage(int amount) {
        
        if(isDead)
            return;

        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0) 
        { 
            Death();
        }
    }

    void Death() {

        isDead = true;
        StartSinking();
        // anim.SetTrigger("Dead");
    }
    
    // For Later use // for now we destroy the enemy object
    public void StartSinking() {

        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        isSinking = true;
        ScoreManager.count += scoreValue;
        Destroy(transform.parent.gameObject);
    }

}
