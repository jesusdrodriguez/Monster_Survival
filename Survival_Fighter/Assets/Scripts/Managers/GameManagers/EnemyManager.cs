using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 5f;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public int count;


    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        if (count > 0)
        {
            Instantiate(enemy, new Vector2(spawnPoint1.position.x, spawnPoint1.position.y), Quaternion.identity);
            count--;
        }
        else
            return;
    }
}
