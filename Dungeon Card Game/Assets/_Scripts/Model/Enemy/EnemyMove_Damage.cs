using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Card Game/EnemyMoves/Damage")]
public class EnemyMove_Damage : EnemyMove
{
    [SerializeField]
    private int intDamage = 0;

    public override void Execute(CombatField pCombatField)
    {
        if (pCombatField.PlayerMonster != null)
        {
            pCombatField.Damage_PlayerMonster(intDamage);
        }
        else
        {
            pCombatField.Damage_Player(intDamage);
        }
    }
}
