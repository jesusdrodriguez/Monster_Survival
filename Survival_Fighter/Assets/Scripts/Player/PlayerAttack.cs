using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage;

    Animator anim;
    GameObject enemy;
    EnemyHealth enemyHealth;
    bool enemyInRange;
    bool canAttack;
    float timer;

    // Use this for initialization
    void Awake()
    {

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {
            canAttack = true;
        }

        if (timer >= timeBetweenAttacks && enemyInRange && enemyHealth.currentHealth > 0 && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;

        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
