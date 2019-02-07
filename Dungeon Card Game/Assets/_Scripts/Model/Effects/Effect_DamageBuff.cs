using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Card Game/Effects/PlayerMonster_DamageBuff")]
public class Effect_DamageBuff : Effect
{
    [SerializeField]
    private int intDamageBuff = 0;

    public override void Activate(Game pGame)
    {
        PlayerMonster monster = pGame.CombatField.PlayerMonster;
        if (monster != null)
        {
            monster.Damage += intDamageBuff;
        }
    }
}
