using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster {

    //Variables
    private Enemy enemy;

    private int intHealth;
    private int intHealthBuff = 0;

    private int intCurrentMove = 0;

    //Constructor
    public EnemyMonster(Enemy pEnemy)
    {
        enemy = pEnemy;
        intHealth = enemy.Health;
    }

    //Properties
    public Enemy Enemy
    {
        get
        {
            return enemy;
        }
    }

    public int MaxHealth
    {
        get
        {
            return enemy.Health + intHealthBuff;
        }
        set
        {
            intHealthBuff = value - enemy.Health;
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
    
    public bool Dead
    {
        get
        {
            return intHealth == 0;
        }
    }

    //Functions
    public void ExecuteNextMove(CombatField pCombatField)
    {
        enemy.MoveSet.Get(intCurrentMove).Execute(pCombatField);

        intCurrentMove = (intCurrentMove + 1) % enemy.MoveSet.Size;
    }
}
