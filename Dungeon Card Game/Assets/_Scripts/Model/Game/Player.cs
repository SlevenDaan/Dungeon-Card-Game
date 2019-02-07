using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Variabels
    private const int STARTING_HEALTH = 10;
    private int intHealth = STARTING_HEALTH;
    private int intMaxHealth = STARTING_HEALTH;

    private int intEnergy;

    //Properties
    public int Health
    {
        get
        {
            return intHealth;
        }
        set
        {
            intHealth = Mathf.Clamp(value, 0, intMaxHealth);
        }
    }

    public int MaxHealth
    {
        get
        {
            return intMaxHealth;
        }
    }

    public bool Dead
    {
        get
        {
            return intHealth == 0;
        }
    }

    public int Energy
    {
        get
        {
            return intEnergy;
        }
        set
        {
            intEnergy = value;
            if (intEnergy < 0)
            {
                intEnergy = 0;
            }
        }
    }

    //Functions

}
