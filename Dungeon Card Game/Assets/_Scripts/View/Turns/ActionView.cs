using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionView : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Text textAction;
    
	void Start () {
        gameManager.OnRequestDiscard += DisplayAction_Discard;
        gameManager.OnRequestPlayArena += DisplayAction_Arena;
        gameManager.OnRequestPlayMonster += DisplayAction_Monster;
        gameManager.OnRequestPlaySpell += DisplayAction_Spell;
    }

    private void SetText(string strMessage)
    {
        textAction.text = strMessage;
    }

    private void DisplayAction_Discard()
    {
        SetText("Discard a card");
    }
    private void DisplayAction_Arena()
    {
        SetText("Play an arena");
    }
    private void DisplayAction_Monster()
    {
        SetText("Play a monster");
    }
    private void DisplayAction_Spell()
    {
        SetText("Play a spell");
    }
}
