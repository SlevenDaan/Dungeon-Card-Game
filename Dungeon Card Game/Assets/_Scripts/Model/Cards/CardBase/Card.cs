using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName="New Monster",menuName="Card Game/<name>")]
public abstract class Card : ScriptableObject
{

    //Variables
    [SerializeField]
    private Sprite image;
    [SerializeField]
    private string strName;
    [SerializeField]
    private int intCost;
    [SerializeField]
    private int intEnergy;

    //Properties
    public string Name
    {
        get
        {
            return strName;
        }
    }
    public int Cost
    {
        get
        {
            return intCost;
        }
    }
    public int Energy
    {
        get
        {
            return intEnergy;
        }
    }
    public Sprite Image
    {
        get
        {
            return image;
        }
    }

    public abstract string Description
    {
        get;
    }

}
