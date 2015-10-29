using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

    //public static int amount = 0;
    public int MaxAmmo = 500;
    public int StartingAmmo = 500;
    public int currentAmmo;
    public bool hasAmmo = true;

    void Start () {

        currentAmmo = StartingAmmo;
    }

	// Update is called once per frame
	void Update () {

        if (currentAmmo >= MaxAmmo)
        {
            currentAmmo = MaxAmmo;
        }
        if (currentAmmo > 0)
        {
            hasAmmo = true;
        }
        else
            hasAmmo = false;
	}

    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
    }
}