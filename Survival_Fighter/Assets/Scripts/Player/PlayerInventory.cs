using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

    int MaxAmmo = 500;
    int StartingAmmo = 150;
    public int currentAmmo;
    PlayerAttack playerAttack;

    void Awake()
    {
        currentAmmo = StartingAmmo;
    }

	// Update is called once per frame
	void Update () {

        if(currentAmmo >= MaxAmmo)
        {
            currentAmmo = MaxAmmo;
        }
        
	}


    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
    }
}
