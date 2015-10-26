using UnityEngine;
using System.Collections;

public class PlayerEquip : MonoBehaviour
{
    //public Sprite newSprite;
    GameObject pickupM;
    GameObject pickupG;
    GameObject CurrentWep;
    //public Transform playerT;
    Transform pickupT;
    bool isEquiped;
    bool isMelee;
    bool isGun;
    public bool canMelee;
    public bool canShoot;

    void Awake()
    {
        //useDefaultWep();
    }
    void Update()
    {

        if (isEquiped && isMelee)
        {
            canMelee = true;
        }
        if (isEquiped && isGun)
        {
            canShoot = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled) return;

        if (other.gameObject.tag == "Melee" && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(other.gameObject);
            //other.gameObject.transform.parent = CurrentWep.transform.FindChild("Player");
            //CurrentWep.transform.parent = null;
            //other.gameObject.SetActive(false);
            isEquiped = true;
            isMelee = true;
            Debug.Log("Picked up a melee wep!");
            
            // PickupItem(temp);
        }
        if (other.gameObject.tag == "Gun" && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(other.gameObject);
            //other.gameObject.transform.parent = CurrentWep.transform.FindChild("Player");
            //other.gameObject.SetActive(false);
            isEquiped = true;
            isGun = true;            
            Debug.Log("Picked up a gun wep!");
        }
    }
    /*
    public void defaultWep() {
        // default wep sprite here
    }
    public void PickupItem(GameObject pickup) {
        if(pickup.gameObject.tag == "gun")
        {
            sprite for gun here
        }
    }*/
}
