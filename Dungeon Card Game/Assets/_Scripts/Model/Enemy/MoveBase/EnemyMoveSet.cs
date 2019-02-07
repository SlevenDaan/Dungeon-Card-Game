using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Effect",menuName="Card Game/EnemyMoveSet")]
public class EnemyMoveSet : ScriptableObject {

    //Variables
    [SerializeField]
    private EnemyMove[] arrMoves = new EnemyMove[0];

    //Constructor

    //Properties
    public int Size
    {
        get
        {
            return arrMoves.Length;
        }
    }

    //Functions
    public EnemyMove Get(int pIndex)
    {
        if (pIndex < Size)
        {
            return arrMoves[pIndex];
        }
        else
        {
            return null;
        }
    }

}
