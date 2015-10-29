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
        if(count > 0)
        {
            Instantiate(enemy, new Vector2(spawnPoint1.position.x, spawnPoint1.position.y), Quaternion.identity);
            Instantiate(enemy, new Vector2(spawnPoint2.position.x, spawnPoint2.position.y), Quaternion.identity);
            count--;
        }
    }
}


/*
* Waves Logic
*
 * 
        if(wave==1 && timer >= timeBetweenSpawns)
        {
            int temp = count;
            for (int i = 0; i < count; i++)
            {
                Instantiate(enemy, new Vector2(spawnPoint1.position.x, spawnPoint1.position.y), Quaternion.identity);
                Instantiate(enemy, new Vector2(spawnPoint2.position.x, spawnPoint2.position.y), Quaternion.identity);
                count--;
            }
            if (killcount == temp)
            {
                timer = 10f;
                wave++;
                count = 10;
            }
            else return;
        }
        if(wave==2 && timer >= timeBetweenSpawns)
        {
            int temp = count;
            for (int i = 0; i < count; i++)
            {
                Instantiate(enemy, new Vector2(spawnPoint1.position.x, spawnPoint1.position.y), Quaternion.identity);
                Instantiate(enemy, new Vector2(spawnPoint2.position.x, spawnPoint2.position.y), Quaternion.identity);
                count--;
            }
            if (killcount == temp)
            {
                timer = 10f;
                wave++;
                count = 15;
            }
            else return;
        }
        if (wave == 3 && timer >= timeBetweenSpawns)
        {
            int temp = count;
            for (int i = 0; i < count; i++)
            {
                Instantiate(enemy, new Vector2(spawnPoint1.position.x, spawnPoint1.position.y), Quaternion.identity);
                Instantiate(enemy, new Vector2(spawnPoint2.position.x, spawnPoint2.position.y), Quaternion.identity);
                count--;
            }
            if (killcount == temp)
            {
                timer = 20f;
                wave++;
                count = 20;
            }
            else return;
        }
    }
 */