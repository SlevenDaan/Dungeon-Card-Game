using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaView : MonoBehaviour {

    //Variables
    [SerializeField]
    private Text textName;
    [SerializeField]
    private Text textDescription;

    //Constructor
    void Start () {
        Hide();
	}

    //Functions
    public void Display(Card_Arena pCard)
    {
        gameObject.SetActive(true);
        textName.text = pCard.Name;
        textDescription.text = pCard.Description;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
