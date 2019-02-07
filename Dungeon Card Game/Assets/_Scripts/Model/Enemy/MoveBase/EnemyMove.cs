using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName="New Effect",menuName="Card Game/EnemyMoves/<name>")]
public abstract class EnemyMove : ScriptableObject {

    //Functions
    public abstract void Execute(CombatField pCombatField);

}
