using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerInventory playerInventory;

    public bool GunIsEquiped;
    public bool MeleeIsEquiped = true;
    public bool NukeActivated;
    public bool canMelee;
    public bool canShoot;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerInventory = GetComponent<PlayerInventory>();
        canMelee = true;
    }
    void Update()
    {/*
        if (MeleeIsEquiped && canMelee)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = img1;
            canMelee = true;
            MeleeIsEquiped = false;
        }
        if (GunIsEquiped && canShoot)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = img2;
            canShoot = true;
            GunIsEquiped = false;
        }*/
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled) return;

        if (other.gameObject.tag == "Melee")
        {
            Destroy(other.gameObject);
            MeleeIsEquiped = true;
            Debug.Log("Picked up a melee wep!");
        }
        if (other.gameObject.tag == "Gun")
        {
            Destroy(other.gameObject);
            GunIsEquiped = true;            
            Debug.Log("Picked a weapon!");
        }
        if (other.gameObject.tag == "FirstAid")
        {
            Destroy(other.gameObject);
            playerHealth.HealHealth(50);
            Debug.Log("Healed by FirstAid!");
        }
        if (other.gameObject.tag == "Nuke")
        {
            Destroy(other.gameObject);
            NukeActivated = true;
            Debug.Log("Activated a Nuke!");
        }
        if (other.gameObject.tag == "Ammo")
        {
            Destroy(other.gameObject);
            playerInventory.AddAmmo(50);
            Debug.Log("Picked up Ammo!");
        }
    }
}
