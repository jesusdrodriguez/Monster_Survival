using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public float timeBetweenBullets = 0.15f;
    public float speed = 2f;
    public int attackDamage = 20;
    public int bulletDamage = 30;
    public float rangeMelee = 1f;
    public float rangeGun = 100f;

    // BulletBehaviour
    public GameObject bullet;
    public Transform shootFrom;
    public float distance = 10.0f;

    Animator anim;
    GameObject enemy;
    EnemyHealth enemyHealth;
    int AttackableMask;
    bool enemyInRange;
    public bool shooted;
    
    //boolean checks for current equiped item
    //bool canMelee;
    bool canShoot;

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

        PlayerPickup playerPickup = GetComponent<PlayerPickup>();

        if(Input.GetKeyDown(KeyCode.Alpha1) && playerPickup.MeleeIsEquiped)
        {
            playerPickup.canShoot = false;
            playerPickup.canMelee = true;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerPickup.GunIsEquiped)
        {
            playerPickup.canShoot = true;
            playerPickup.canMelee = false;
        }

        timer += Time.deltaTime;

        // && canMelee - condition for current equiped item
        if (Input.GetKeyDown(KeyCode.E) && timer >= timeBetweenAttacks && enemyInRange && playerPickup.canMelee)
        {
            MeleeAttack();
        }
        // && canShoot - condition for current equiped item
        if(Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets && playerPickup.canShoot)
        {
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

        timer = 0f;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 dir = mousePos - transform.position;
        Debug.Log(dir);
        shootBullet(dir);
        Ray shootRay = new Ray(dir, Vector2.down);

        RaycastHit2D shootHit = Physics2D.Raycast(shootRay.origin, -shootRay.direction, rangeGun, AttackableMask);

        PlayerInventory playerInventory = GetComponent<PlayerInventory>();
        playerInventory.currentAmmo--;
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
        GameObject bulletx = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        bulletx.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletx.GetComponent<Rigidbody>().AddForce(direction.normalized * 50, ForceMode.VelocityChange);
    }
}



/*
 * 
 *  /*
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (transform.position.z - Camera.main.transform.position.z);
        
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        shootRay = new Ray(worldPos, Vector2.down);

        Debug.Log(worldPos);

        transform.LookAt(worldPos, Vector3.forward);
        shootHit = Physics2D.Raycast(shootRay.origin, shootRay.direction, rangeGun, AttackableMask);
        */
/* 
void GunAttack() {

       Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
       position = Camera.main.ScreenToWorldPoint(position);
       GameObject go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
       go.transform.LookAt(position);
       Debug.Log(position);
       shootRay = new Ray(position, Vector2.down);
       shootHit = Physics2D.Raycast(shootRay.origin, shootRay.direction, rangeGun, AttackableMask);

       rb = bullet.GetComponent<Rigidbody2D>();
       go.rigidbody2D.AddForce(transform.forward * 1000);

       PlayerInventory playerInventory = GetComponent<PlayerInventory>();
       playerInventory.currentAmmo--;
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
 
 * void GunAttack()
   {
       // ... set the animator Shoot trigger parameter and play the audioclip.
       //anim.SetTrigger("Shoot");
       //audio.Play();
       timer = 0f;
       Vector3 target;
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << AttackableMask))
       {
           //hit.collider.tag.Equals("Enemy")
           if (hit.collider.GetComponent<EnemyHealth>().tag == ("Enemy"))
           {
               EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
               if(enemyHealth != null)
               {
                   enemyHealth.TakeDamage(bulletDamage);
               }
               Debug.Log(hit.collider);
               target = hit.point - transform.position;
               shootBullet(target);
               PlayerInventory playerInventory = GetComponent<PlayerInventory>();
               playerInventory.currentAmmo--;
           }
       }
   }
 * 
*/