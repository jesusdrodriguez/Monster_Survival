using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour {

    //GameObject pickup;
    GameObject player;
    bool isPicked;

    void Awake() {

        //defaultWep();
        //player = GameObject.FindGameObjectWithTag("Player");
        //pickup = GameObject.FindGameObjectWithTag("Pickup");
    }

    void Update() {

        if (isPicked)
        {
            Debug.Log("isPicked");
        }

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
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
