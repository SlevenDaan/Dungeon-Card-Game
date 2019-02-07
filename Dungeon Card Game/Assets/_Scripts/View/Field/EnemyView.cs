using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour {

    //Variables
    [SerializeField]
    private Text textName;
    [SerializeField]
    private Text textHealth;

    //Constructor
    void Start () {
        Hide();
	}

    //Functions
    public void Display(EnemyMonster pMonster)
    {
        gameObject.SetActive(true);
        textName.text = pMonster.Enemy.Name;
        textHealth.text = pMonster.Health + "/" + pMonster.MaxHealth;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
