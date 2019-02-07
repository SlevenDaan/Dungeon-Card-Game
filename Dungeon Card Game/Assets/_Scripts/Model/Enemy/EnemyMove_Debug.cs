using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Card Game/EnemyMoves/Debug")]
public class EnemyMove_Debug : EnemyMove
{
    [SerializeField]
    private string strDescription;

    public override void Execute(CombatField pCombatField)
    {
        Debug.Log(strDescription);
    }
}
