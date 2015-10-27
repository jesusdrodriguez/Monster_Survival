using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public float timeBetweenBullets = 0.15f;
    public int attackDamage = 20;
    public int bulletDamage = 30;
    public float rangeMelee = 1f;
    public float rangeGun = 100f;

    Animator anim;
    GameObject enemy;
    EnemyHealth enemyHealth;

    //Using Physics and Masking
    Ray2D shootRay;
    RaycastHit2D shootHit;
    int AttackableMask;

    //PlayerEquip pickup;
    bool enemyInRange;

    //boolean checks for current equiped item
    //bool canMelee;
    //bool canGun;

    float timer;

    void Awake() {

        AttackableMask = LayerMask.GetMask("CanBeAttacked");
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

        timer += Time.deltaTime;

        // && canMelee - condition for current equiped item
        if (Input.GetKeyDown(KeyCode.E) && timer >= timeBetweenAttacks && enemyInRange)
        {
            MeleeAttack();
        }
        // && canGun - condition for current equiped item
        if(Input.GetButton("Fire1") && timer >= timeBetweenBullets && enemyInRange)
        {
            GunAttack();
        }
    }

    void MeleeAttack() {

        timer = 0f;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        shootHit = Physics2D.Raycast(transform.position, transform.right, rangeMelee, AttackableMask); 

        if (shootHit)
        {
            Debug.Log(shootHit.collider);
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    void GunAttack()
    {

        timer = 0f;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        shootHit = Physics2D.Raycast(transform.position, transform.right, rangeMelee, AttackableMask);

        if (shootHit)
        {
            Debug.Log(shootHit.collider);
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
}
