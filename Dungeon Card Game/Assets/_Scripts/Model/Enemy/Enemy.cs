using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Enemy",menuName="Card Game/Enemy")]
public class Enemy : ScriptableObject {

    //Variables
    [SerializeField]
    private string strName;
    [SerializeField]
    private EnemyMoveSet moveSet;

    [SerializeField]
    [Range(1,1000000)]
    private int intHealth = 1;

    //Properties
    public int Health
    {
        get
        {
            return intHealth;
        }
    }

    public string Name
    {
        get
        {
            return strName;
        }
    }

    public EnemyMoveSet MoveSet
    {
        get
        {
            return moveSet;
        }
    }
}
