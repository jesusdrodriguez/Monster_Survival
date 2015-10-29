using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    EnemyHealth enemyHealth;
    int amount = 8;

	// Update is called once per frame
    void Start() {

    }
	void Update () {

        Destroy(gameObject, 2f);
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Bullet entered a collider");
            enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(amount);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
}
