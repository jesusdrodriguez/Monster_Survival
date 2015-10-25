using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {

    //GameObject pickup;
    GameObject player;
    bool isPicked;

    void Awake() {

        //player = GameObject.FindGameObjectWithTag("Player");
        //pickup = GameObject.FindGameObjectWithTag("Pickup");
    }

    void Update() {

        if(isPicked)
        {
            
        }

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Picked up a wep!");
            isPicked = true;
           // PickupItem(temp);
        }
    }
    /*
    public void defaultWep() {
        
    }

    public void PickupItem(GameObject pickup) {

        if(pickup.gameObject.tag == "AK")
        {
            defaultWep();
        }

    }*/
}
