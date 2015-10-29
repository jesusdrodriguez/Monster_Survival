using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public AudioClip deathClip;
    AudioSource enemyAudio;
    public int startingHealth = 200;
    public int currentHealth;    
    float sinkSpeed = 0.5f;
    int scoreValue = 1;

    // drop items
    public GameObject Ammo;
    public GameObject FirstAid;
    public GameObject Gun;
    public GameObject Melee;
    public GameObject Nuke;
    //

    Animator anim;
    public Slider healthSlider;
    EnemyAttack enemyAttack;
    EnemyMovement enemyMovement;
    bool isSinking;
    bool isDead;

	// Use this for initialization
    void Awake() {

        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update() {

        if(isSinking)
        {
            transform.Translate(-Vector2.up * sinkSpeed * Time.deltaTime);
        }
	}

    //
    public void TakeDamage(int amount) {
        
        if(isDead)
            return;

        currentHealth -= amount;
        healthSlider.value = currentHealth;

        float rand = Random.Range(0f, 1f);

        if (currentHealth <= 0) 
        { 
            Death();

            if(rand >= 0.25f)
            {
                //do nothing
            }
            else if (rand <= 0.25f)
            {
                GameObject.Instantiate(Ammo, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            else if (rand <= 0.12f)
            {
                GameObject.Instantiate(FirstAid, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            else if (rand <= 0.06f)
            {
                GameObject.Instantiate(Gun, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            else if (rand <= 0.02f)
            {
                GameObject.Instantiate(Nuke, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }
    }

    void Death() {

        isDead = true;
        StartSinking();
        anim.SetTrigger("Dead");
        enemyAudio.Play();
    }
    
    // For Later use // for now we destroy the enemy object
    public void StartSinking() {

        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        isSinking = true;
        ScoreManager.count += scoreValue;
        Destroy(transform.parent.gameObject, 2f);
    }

}
