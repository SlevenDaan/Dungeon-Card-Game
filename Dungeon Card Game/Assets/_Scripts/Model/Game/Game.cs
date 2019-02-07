using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    //Variables
    [SerializeField]
    private Hand hand;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Player player;
    [SerializeField]
    private CombatField combatField;

    //Properties
    public Hand Hand
    {
        get
        {
            return hand;
        }
    }
    public Deck Deck
    {
        get
        {
            return deck;
        }
    }
    public Player Player
    {
        get
        {
            return player;
        }
    }
    public CombatField CombatField
    {
        get
        {
            return combatField;
        }
    }

    //Functions
    public void Draw(int pAmount)
    {
        for(int intT = 0; intT < pAmount; intT++)
        {
            Draw();
        }
    }

    public void Draw()
    {
        Card newCard = deck.Draw();
        if (newCard != null)
        {
            hand.Add(newCard);
        }
        else
        {
            player.Health -= 1;
        }
    }

    public void Discard(int pIndex)
    {
        Card thisCard = hand.Get(pIndex);
        player.Energy += thisCard.Energy;
        if (thisCard.GetType() == typeof(Card_Monster)){
            //TRIGGER: Abandon
            ((Card_Monster)thisCard).ActivateEffect(EffectType_Monster.Abandon,this);
        }
        hand.Remove(pIndex);
    }

    public bool Play(int pIndex)//Returns false if not enough energy
    {
        Card thisCard = hand.Get(pIndex);
        if (CheckIfEnoughEnergy(thisCard))
        {
            thisCard = hand.Play(pIndex);

            if (thisCard.GetType() == typeof(Card_Arena))
            {
                Play((Card_Arena)thisCard);
            }
            else if (thisCard.GetType() == typeof(Card_Monster))
            {
                Play((Card_Monster)thisCard);
            }
            else if (thisCard.GetType() == typeof(Card_Spell))
            {
                Play((Card_Spell)thisCard);
            }
            PayForCard(thisCard);
            return true;
        }
        Debug.Log("Not Enough Energy " + player.Energy + "/" + thisCard.Cost);
        return false;
    }
    private void Play(Card_Arena pCard)
    {
        combatField.SetArena(pCard);
    }
    private void Play(Card_Monster pCard)
    {
        //TRIGGER: Summon
        if (combatField.Arena != null)
        {
            combatField.Arena.ActivateEffect(EffectType_Arena.Summon,this);
        }
        combatField.Spawn(pCard);
    }
    private void Play(Card_Spell pCard)
    {
        //TRIGGER: Cast
        if (combatField.Arena != null)
        {
            combatField.Arena.ActivateEffect(EffectType_Arena.Cast,this);
        }
        pCard.GetEffect().Activate(this);
        combatField.CheckPlayerMonsterDead();
        combatField.CheckEnemyMonsterDead();
    }
    private bool CheckIfEnoughEnergy(Card pCard)
    {
        return pCard.Cost <= player.Energy;
    }
    private void PayForCard(Card pCard)
    {
        player.Energy -= pCard.Cost;
    }

    public void ExecutePlayerCombat()
    {
        combatField.Execute_Combat_Player();
    }

    public void EndOfPlayerTurn()
    {
        player.Energy = 0;
    }

    public void ExecuteEnemyCombat()
    {
        combatField.Execute_Combat_Enemy();
    }
}
