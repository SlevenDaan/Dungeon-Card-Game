using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonster {

    //Variables
    private Card_Monster card;

    private int intHealth;
    private int intHealthBuff = 0;

    private int intDamageBuff = 0;

    //Constructor
    public PlayerMonster(Card_Monster pCard)
    {
        card = pCard;
        intHealth = card.Defense;
    }

    //Properties
    public Card_Monster Card
    {
        get
        {
            return card;
        }
    }

    public int MaxHealth
    {
        get
        {
            return card.Defense + intHealthBuff;
        }
        set
        {
            intHealthBuff = value - card.Defense;
        }
    }
    public int Health
    {
        get
        {
            return intHealth;
        }
        set
        {
            intHealth = Mathf.Clamp(value, 0, MaxHealth);
        }
    }

    public int Damage
    {
        get
        {
            return card.Damage + intDamageBuff;
        }
        set
        {
            intDamageBuff = value - card.Damage;
        }
    }

    public bool Dead
    {
        get
        {
            return intHealth == 0;
        }
    }

    //Functions

}
