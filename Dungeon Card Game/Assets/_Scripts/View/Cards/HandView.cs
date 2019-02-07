using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandView : MonoBehaviour {

	//Variables
	[SerializeField]
	private GameManager gameManager;

	[SerializeField]
	private GameObject prefabCardViewObject;
	[SerializeField]
	private GameObject goCardHolder;
	private List<GameObject> arrCardViews = new List<GameObject>();
    [SerializeField]
    private float fltCardWidth = 0.3f;

    [SerializeField]
    private GameObject goSkipButton;

    //Constructor
    void Start()
    {
        HideNextTurnStateButton();

        gameManager.OnRequestDiscard += ShowDiscards;
        gameManager.OnRequestPlayArena += ShowArenaCards;
        gameManager.OnRequestPlayMonster += ShowMonsterCards;
        gameManager.OnRequestPlaySpell += ShowSpellCards;
        gameManager.Game.Hand.HandChanged += DisplayCards;
    }

    //Properties

    //Functions
    void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			gameManager.NextTurnState ();
		}
	}

	private void ShowDiscards(){
		EnableDiscards ();
		ShowNextTurnStateButton ();
	}
	private void ShowArenaCards(){
		EnableArenaCards ();
		ShowNextTurnStateButton ();
	}
	private void ShowMonsterCards(){
		EnableMonsterCards ();
		ShowNextTurnStateButton ();
	}
	private void ShowSpellCards(){
		EnableSpellCards ();
		ShowNextTurnStateButton ();
	}

    private void EnableDiscards()
    {
        foreach (GameObject goCard in arrCardViews)
        {
            CardView cardView = goCard.GetComponent<CardView>();
            cardView.State = CardViewState.Discard;
        }
    }
    private void EnableArenaCards()
    {
        foreach (GameObject goCard in arrCardViews)
        {
            CardView cardView = goCard.GetComponent<CardView>();
            if (cardView.Card.GetType() == typeof(Card_Arena))
            {
                cardView.State = CardViewState.Playable;
            }
            else
            {
                cardView.State = CardViewState.Disabled;
            }
        }
    }
    private void EnableMonsterCards()
    {
        foreach (GameObject goCard in arrCardViews)
        {
            CardView cardView = goCard.GetComponent<CardView>();
            if (cardView.Card.GetType() == typeof(Card_Monster))
            {
                cardView.State = CardViewState.Playable;
            }
            else
            {
                cardView.State = CardViewState.Disabled;
            }
        }
    }
    private void EnableSpellCards()
    {
        foreach (GameObject goCard in arrCardViews)
        {
            CardView cardView = goCard.GetComponent<CardView>();
            if (cardView.Card.GetType() == typeof(Card_Spell))
            {
                cardView.State = CardViewState.Playable;
            }
            else
            {
                cardView.State = CardViewState.Disabled;
            }
        }
    }

    private void DisplayCards(Hand pHand)
    {
        ClearDisplayedCards();
        for (int intC = 0; intC < pHand.Size; intC++)
        {
            Card pCard = pHand.Get(intC);
            GameObject goCard = Instantiate(prefabCardViewObject, goCardHolder.transform);
            goCard.transform.Translate(Vector3.right * ((-pHand.Size+1f)/2f+intC) * fltCardWidth);
            goCard.GetComponent<CardView>().Init(intC, gameManager, this, pCard);
            arrCardViews.Add(goCard);
        }
    }
    private void ClearDisplayedCards()
    {
        foreach (GameObject goCard in arrCardViews)
        {
            Destroy(goCard);
        }
        arrCardViews.Clear();
    }

    private void ShowNextTurnStateButton()
    {
        goSkipButton.SetActive(true);
    }
    public void HideNextTurnStateButton()
    {
        goSkipButton.SetActive(false);
    }
}
