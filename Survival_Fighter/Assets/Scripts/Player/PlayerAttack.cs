using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public float timeBetweenBullets = 0.1f;
    public float speed = 2f;
    public int attackDamage = 20;
    public int bulletDamage = 35;
    public float rangeMelee = 1f;
    public float rangeGun = 100f;

    // BulletBehaviour
    public GameObject bullet;
    public Transform shootFrom;

    AudioSource gunAudio;
    Animator anim;
    public Sprite sword, gun;
    GameObject enemy;
    EnemyHealth enemyHealth;
    int AttackableMask;
    bool enemyInRange;
    public bool shooted = false;

    float timer;

    void Awake() {

        anim = GetComponent<Animator>();
        gunAudio = GetComponent<AudioSource>();
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
    void FixedUpdate() {

        PlayerPickup playerPickup = GetComponent<PlayerPickup>();
        PlayerInventory playerInventory = GetComponent<PlayerInventory>();

        if(Input.GetKeyDown(KeyCode.Alpha1) && playerPickup.MeleeIsEquiped)
        {
            playerPickup.canShoot = false;
            playerPickup.canMelee = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sword;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerPickup.GunIsEquiped)
        {
            playerPickup.canShoot = true;
            playerPickup.canMelee = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = gun;
        }

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && timer >= timeBetweenAttacks && enemyInRange && playerPickup.canMelee)
        {
            anim.SetTrigger("Attacking");
            MeleeAttack();            
        }
        if(Input.GetButton("Fire1") && timer >= timeBetweenBullets && playerPickup.canShoot && playerInventory.hasAmmo)
        {
            anim.SetTrigger("Shooting");
            gunAudio.Play();
            GunAttack();
        }
        if(playerPickup.NukeActivated)
        {
            nukeAll();
            playerPickup.NukeActivated = false;
        }

    }

    void MeleeAttack() {

        timer = 0f;
        RaycastHit2D shootHit = Physics2D.Raycast(transform.position, transform.right, rangeMelee, AttackableMask); 

        if (shootHit)
        {
            //Debug.Log(shootHit.collider);
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    void GunAttack() {

        shooted = true;
        timer = 0f;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 dir = mousePos - transform.position;
        Debug.Log(dir);
        shootBullet(dir);
        PlayerInventory playerInventory = GetComponent<PlayerInventory>();
        playerInventory.currentAmmo--;
    }
    
    
    // nuke all exisitng enemies on the terrain
    void nukeAll() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>();
            enemyHealth.TakeDamage(50);
            //Destroy(enemy);
        }
    }

    public void shootBullet(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bulletx = Instantiate(bullet, shootFrom.position, shootFrom.rotation) as GameObject;
        bulletx.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletx.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 50, ForceMode.VelocityChange);
    }
}