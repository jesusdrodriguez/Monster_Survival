using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage;

    Animator anim;
    GameObject enemy;
    EnemyHealth enemyHealth;
    //PlayerEquip pickup;
    bool enemyInRange;
    bool canAttack;
    //bool canMelee;
    //bool canGun;
    float timer;

    // Use this for initialization
    void Awake() {

        //anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = false;
        }
    }

    // Update is called once per frame
    void Update() {
            
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();

        timer += Time.deltaTime;

        // && canMelee
        if (Input.GetKeyDown(KeyCode.E) && enemyInRange)
        {
            if (timer >= timeBetweenAttacks)
            {
                Attack();
            }
        }
        else
            canAttack = false;
    }

    void Attack() {

        timer = 0f;

        enemyHealth.TakeDamage(attackDamage);

    }
}
