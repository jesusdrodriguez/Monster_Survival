using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Animator anim;
    PlayerMovement playerMovement;
    EnemyHealth enemyHealth;
    public int currentHealth;
    public int Damage;
    private Transform target;
    float Distance;
    float MaxDistance = 0.6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //RaycastHit2D hit;
            if(true)
            {
               

            }
        }
	}
}
