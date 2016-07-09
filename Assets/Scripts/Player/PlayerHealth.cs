using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    public AudioClip deathClip;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    bool isDead = false;
    bool damaged;

	// Use this for initialization
	void Awake () {

        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if(currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }

        if(damaged)
        {
            damageImage.enabled = true;
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;      
	}

    public void TakeDamage (int amount) {

        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    public void HealHealth(int amount) {

        currentHealth += amount;
        healthSlider.value = currentHealth;
    }


    void Death() {

        isDead = true;
        anim.SetTrigger("Death");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerMovement.enabled = false;
        playerAttack.enabled = false;
        Delay();
        //loadMainMenu(0);
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(10f);
        loadMainMenu(0);
    }
 
    void loadMainMenu(int level) {

        Application.LoadLevel(level);
    }

    /*public void StartSinking()
    {

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        isSinking = true;
        Destroy(gameObject);
    }*/

}
