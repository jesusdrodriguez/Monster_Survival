using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 200;
    public int currentHealth;    
    float sinkSpeed = 0.5f;
    int scoreValue = 1;

    //Animator anim;
    public RectTransform canvasRectT;
    public RectTransform healthBar;
    public Slider healthSlider;
    public Transform objectToFollow;
    public GameObject enemy;
    public Canvas enemyBar;
    EnemyAttack enemyAttack;
    EnemyMovement enemyMovement;
    BoxCollider2D boxCollider2D;
    bool isSinking;

	// Use this for initialization
    void Awake() {

        //anim = GetComponent<Animator>();

        //to use with bullets //
        //boxCollider2D = GetComponent<BoxCollider2D>();

        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponentInChildren<EnemyAttack>();
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update() {

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, objectToFollow.position);
        healthBar.anchoredPosition = screenPoint - canvasRectT.sizeDelta / 2f;

        if(isSinking)
        {
            transform.Translate(-Vector2.up * sinkSpeed * Time.deltaTime);
        }
	}

    // might require vectory2 hitpoint for bullet impacts
    //
    public void TakeDamage(int amount) {

        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0) 
        { 
            Death();
        }
    }

    void Death() {

        Destroy(enemy);
        enemyBar.enabled = false;
        // use with bullets //
        //boxCollider2D.isTrigger = true;

        StartSinking();
        // anim.SetTrigger("Dead");

    }

    // For Later use // for now we destroy the enemy object
    public void StartSinking() {

        enemyMovement.enabled = false;
        enemyAttack.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        isSinking = true;
        ScoreManager.count += scoreValue;
        Destroy(gameObject, 0.5f);

    }

}
