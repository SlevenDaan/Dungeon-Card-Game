using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatField : MonoBehaviour{

    //Variables
    private PlayerMonster playerMonster = null;
    private EnemyMonster enemyMonster = null;
    private Card_Arena arena = null;

    [SerializeField]
    private Game game;

    public delegate void FieldChanged();
    private FieldChanged onFieldChanged;

    //Properties
    public PlayerMonster PlayerMonster
    {
        get
        {
            return playerMonster;
        }
    }
    public EnemyMonster EnemyMonster
    {
        get
        {
            return enemyMonster;
        }
    }
    public Card_Arena Arena
    {
        get
        {
            return arena;
        }
    }

    //Events
    public event FieldChanged OnFieldChange
    {
        add
        {
            onFieldChanged += value;
        }
        remove
        {
            onFieldChanged -= value;
        }
    }
    public void CallFieldChanged()
    {
        if (onFieldChanged != null)
        {
            onFieldChanged();
        }
    }

    //Functions
    public void Damage_Player(int pAmount)
    {
        game.Player.Health -= pAmount;
        if (game.Player.Health <= 0)
        {
            Debug.Log("You Lost!");
        }
        CallFieldChanged();
    }
    public void Damage_PlayerMonster(int pAmount)
    {
        playerMonster.Health -= pAmount;
        //TRIGGER: Grief
        PlayerMonster.Card.ActivateEffect(EffectType_Monster.Grief, game);
        CheckPlayerMonsterDead();
        CallFieldChanged();
    }
    public void CheckPlayerMonsterDead()
    {
        if (playerMonster.Dead)
        {
            //TRIGGER: Afterlife
            playerMonster.Card.ActivateEffect(EffectType_Monster.Afterlife, game);
            playerMonster = null;
            
            if (arena != null)
            {
                //TRIGGER: Defeat
                arena.ActivateEffect(EffectType_Arena.Defeat, game);
            }
        }
    }
    public void Damage_EnemyMonster(int pAmount)
    {
        if (enemyMonster != null)
        {
            enemyMonster.Health -= pAmount;
            CheckEnemyMonsterDead();
            CallFieldChanged();
        }
    }
    public void CheckEnemyMonsterDead()
    {
        if (enemyMonster.Dead)
        {
            enemyMonster = null;
            //TRIGGER: Victory
            if (arena != null)
            {

                arena.ActivateEffect(EffectType_Arena.Victory, game);
            }
        }
    }

    public void Execute_Combat_Player()
    {
        if (playerMonster != null)
        {
            if (playerMonster.Damage > 0)
            {
                //TRIGGER: Triumph
                playerMonster.Card.ActivateEffect(EffectType_Monster.Triumph, game);
            }
            Damage_EnemyMonster(playerMonster.Damage);
        }
    }
    public void Execute_Combat_Enemy()
    {
        if (enemyMonster != null)
        {
            enemyMonster.ExecuteNextMove(this);
        }
        else
        {
            Debug.Log("You Won!");
        }
    }

    public void Spawn(Enemy pEnemy)
    {
        enemyMonster = new EnemyMonster(pEnemy);
        CallFieldChanged();
    }
    public void Spawn(Card_Monster pCard)
    {
        playerMonster = new PlayerMonster(pCard);
        //TRIGGER: Birth
        playerMonster.Card.ActivateEffect(EffectType_Monster.Birth, game);
        CallFieldChanged();
    }
    public void SetArena(Card_Arena pCard)
    {
        arena = pCard;
        CallFieldChanged();
    }
}
