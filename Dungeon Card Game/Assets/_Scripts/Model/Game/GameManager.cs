using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState
{
    Draw, Discard, PlayArena, PlayMonster, PlaySpells, Combat, EndOfTurn, EnemyTurn
}

public class GameManager : MonoBehaviour
{

    //Variables
    private const float fltTimeToWaitOnCombat = 0.5f;
    [SerializeField]
    private Game game;

    private TurnState turnState = TurnState.Draw;

    public delegate void RequestDiscard();
    private RequestDiscard requestDiscard;
    public delegate void RequestPlayArena();
    private RequestPlayArena requestPlayArena;
    public delegate void RequestPlayMonster();
    private RequestPlayMonster requestPlayMonster;
    public delegate void RequestPlaySpell();
    private RequestPlaySpell requestPlaySpell;

    //Debugging
    public Card[] arrCards = new Card[0];
    public Enemy debugEnemy;
    void Start()
    {
        game.CombatField.Spawn(debugEnemy);

        foreach (Card pCard in arrCards)
        {
            game.Deck.AddToBottom(pCard);
            game.Deck.Shuffle();
        }

        game.Draw(3);
        ExecuteTurnState();
    }

    //Properties
    public Game Game
    {
        get
        {
            return game;
        }
    }

    //Events
    public event RequestDiscard OnRequestDiscard
    {
        add
        {
            requestDiscard += value;
        }
        remove
        {
            requestDiscard -= value;
        }
    }
    public event RequestPlayArena OnRequestPlayArena
    {
        add
        {
            requestPlayArena += value;
        }
        remove
        {
            requestPlayArena -= value;
        }
    }
    public event RequestPlayMonster OnRequestPlayMonster
    {
        add
        {
            requestPlayMonster += value;
        }
        remove
        {
            requestPlayMonster -= value;
        }
    }
    public event RequestPlaySpell OnRequestPlaySpell
    {
        add
        {
            requestPlaySpell += value;
        }
        remove
        {
            requestPlaySpell -= value;
        }
    }

    //Functions
    public void NextTurnState()
    {
        turnState = (TurnState)(((int)turnState + 1) % 8);
        ExecuteTurnState();
    }
    private void ExecuteTurnState()
    {
        //Debug.Log("State: " + turnState.ToString());
        switch (turnState)
        {
            case TurnState.Draw:
                TurnState_Draw();
                break;
            case TurnState.Discard:
                TurnState_Discard();
                break;
            case TurnState.PlayArena:
                TurnState_PlayArena();
                break;
            case TurnState.PlayMonster:
                TurnState_PlayMonster();
                break;
            case TurnState.PlaySpells:
                TurnState_PlaySpell();
                break;
            case TurnState.Combat:
                StartCoroutine(TurnState_Combat());
                break;
            case TurnState.EndOfTurn:
                TurnState_EndOfTurn();
                break;
            case TurnState.EnemyTurn:
                StartCoroutine(TurnState_EnemyTurn());
                break;
        }
    }

    ////Turn Calls
    private void TurnState_Draw()
    {
        game.Draw();
        game.Draw();
        NextTurnState();
    }

    private void TurnState_Discard()
    {
        if (requestDiscard != null)
        {
            requestDiscard();
        }
    }
    public void Discard(int pIndex)
    {
        game.Discard(pIndex);
        ExecuteTurnState();
    }

    private void TurnState_PlayArena()
    {
        if (requestPlayArena != null)
        {
            requestPlayArena();
        }
    }
    public void Play_Arena(int pIndex)
    {
        if (!game.Play(pIndex))
        {
            ExecuteTurnState();
        }
        else
        {
            NextTurnState();
        }
    }

    private void TurnState_PlayMonster()
    {
        if (requestPlayMonster != null)
        {
            requestPlayMonster();
        }
    }
    public void Play_Monster(int pIndex)
    {
        Play_Arena(pIndex);
    }

    private void TurnState_PlaySpell()
    {
        if (requestPlaySpell != null)
        {
            requestPlaySpell();
        }
    }
    public void Play_Spell(int pIndex)
    {
        game.Play(pIndex);
        ExecuteTurnState();
    }

    private IEnumerator TurnState_Combat()
    {
        game.ExecutePlayerCombat();
        yield return new WaitForSeconds(fltTimeToWaitOnCombat);
        NextTurnState();
    }

    private void TurnState_EndOfTurn()
    {
        game.EndOfPlayerTurn();
        NextTurnState();
    }

    private IEnumerator TurnState_EnemyTurn()
    {
        game.ExecuteEnemyCombat();
        yield return new WaitForSeconds(fltTimeToWaitOnCombat);
        NextTurnState();
    }

}
