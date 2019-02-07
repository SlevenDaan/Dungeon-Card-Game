using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardViewState{
	Disabled,Discard,Playable
}

public class CardView : MonoBehaviour
{

    //Variables
    private int intIndex;
    private Card card;
    private GameManager gameManager;
    private HandView handView;

    private CardViewState state = CardViewState.Disabled;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text textName;
    [SerializeField]
    private Text textDescription;
    [SerializeField]
    private Text textCost;
    [SerializeField]
    private Text textEnergy;
    [SerializeField]
    private Text textDamage;
    [SerializeField]
    private Text textDefense;

    //Properties
    public Card Card
    {
        get
        {
            return card;
        }
    }

    public CardViewState State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }

    //Functions
    public void Init(int pIndex, GameManager pGameManager, HandView pHandView, Card pCard)
    {
        handView = pHandView;

        card = pCard;

        gameManager = pGameManager;
        intIndex = pIndex;

        image.sprite = card.Image;
        textName.text = card.Name;
        textDescription.text = card.Description;
        textCost.text = card.Cost.ToString();
        textEnergy.text = card.Energy.ToString();
        if (card.GetType() == typeof(Card_Monster))
        {
            textDefense.text = ((Card_Monster)card).Defense.ToString();
            textDamage.text = ((Card_Monster)card).Damage.ToString();
        }
        else
        {
            textDefense.text = "";
            textDamage.text = "";
        }
    }

    void OnMouseDown()
    {
        if (state == CardViewState.Discard)
        {
            gameManager.Discard(intIndex);
        }
        else if (state == CardViewState.Playable)
        {
            if (card.GetType() == typeof(Card_Arena))
            {
                gameManager.Play_Arena(intIndex);
            }
            else if (card.GetType() == typeof(Card_Monster))
            {
                gameManager.Play_Monster(intIndex);
            }
            else if (card.GetType() == typeof(Card_Spell))
            {
                gameManager.Play_Spell(intIndex);
            }
        }
    }
    
}
