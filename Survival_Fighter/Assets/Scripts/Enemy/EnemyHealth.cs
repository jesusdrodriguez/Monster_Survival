using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 200;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 1;

    //Animator anim;
    BoxCollider2D boxCollider2D;
    bool isDead = false;
    bool isSinking;

	// Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(isSinking)
        {
            transform.Translate(-Vector2.up * sinkSpeed * Time.deltaTime);
        }
	}

    public void TakeDamage(int amount, Vector2 hitPoint)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        isDead = true;
        boxCollider2D.isTrigger = true;

        // anim.SetTrigger("Dead");

    }
    public void StartSinking()
    {
        GetComponent<Collider2D>().enabled = false;
        isSinking = true;
        ScoreManager.count += scoreValue;
        Destroy(gameObject, 2f);

    }
}
