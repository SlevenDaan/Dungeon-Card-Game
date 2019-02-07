using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterView : MonoBehaviour {

    //Variables
    [SerializeField]
    private Text textName;
    [SerializeField]
    private Text textDescription;
    [SerializeField]
    private Text textHealth;
    [SerializeField]
    private Text textDamage;

    //Constructor
    void Start () {
        Hide();
	}

    //Functions
    public void Display(PlayerMonster pMonster)
    {
        gameObject.SetActive(true);
        textName.text = pMonster.Card.Name;
        textDescription.text = pMonster.Card.Description;
        textHealth.text = pMonster.Health + "/" + pMonster.MaxHealth;
        textDamage.text = pMonster.Damage +" ("+pMonster.Card.Damage+"+"+(pMonster.Damage-pMonster.Card.Damage)+")";
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
