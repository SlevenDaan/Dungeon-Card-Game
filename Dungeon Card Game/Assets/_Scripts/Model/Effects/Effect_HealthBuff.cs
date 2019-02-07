using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Card Game/Effects/PlayerMonster_HealthBuff")]
public class Effect_HealthBuff : Effect
{
    [SerializeField]
    private int intHealthBuff = 0;

    public override void Activate(Game pGame)
    {
        PlayerMonster monster = pGame.CombatField.PlayerMonster;
        if (monster != null)
        {
            monster.MaxHealth += intHealthBuff;
            monster.Health += intHealthBuff;
        }
    }
}
