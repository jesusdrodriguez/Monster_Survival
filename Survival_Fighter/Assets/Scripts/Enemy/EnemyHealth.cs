using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 200;
    public int currentHealth;
    float sinkSpeed = 0.5f;
    int scoreValue = 1;

    //Animator anim;
    GameObject enemy;
    EnemyAttack enemyAttack;
    EnemyMovement enemyMovement;
    BoxCollider2D boxCollider2D;
    bool isDead = false;
    bool isSinking;

	// Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        //to use with bullets //
        //boxCollider2D = GetComponent<BoxCollider2D>();

        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponentInChildren<EnemyAttack>();
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(isSinking)
        {
            transform.Translate(-Vector2.up * sinkSpeed * Time.deltaTime);
        }
	}

    // vectory2 hitpoint
    //
    public void TakeDamage(int amount)
    {
        if (isDead) 
        { 
            return;
        }
        currentHealth -= amount;
        if (currentHealth <= 0) 
        { 
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Destroy(enemy);
        // use with bullets //
        //boxCollider2D.isTrigger = true;

        StartSinking();
        // anim.SetTrigger("Dead");

    }

    // For Later use

    public void StartSinking()
    {
        enemyMovement.enabled = false;
        enemyAttack.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        isSinking = true;
        ScoreManager.count += scoreValue;
        Destroy(gameObject, 0.5f);

    }

}
