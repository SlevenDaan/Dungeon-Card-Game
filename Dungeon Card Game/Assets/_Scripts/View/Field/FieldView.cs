using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldView : MonoBehaviour {

    //Variables
    [SerializeField]
    private CombatField combatField;
    [SerializeField]
    private Game game;

    [SerializeField]
    private MonsterView monsterView;
    [SerializeField]
    private EnemyView enemyView;
    [SerializeField]
    private ArenaView arenaView;
    [SerializeField]
    private Text textPlayer;

    //Constructor

    //Properties

    //Functions
    void Update()
    {
        UpdateArena();
        UpdatePlayerMonster();
        UpdateEnemyMonster();
        UpdatePlayer();
    }

    private void UpdatePlayerMonster()
    {
        if (combatField.PlayerMonster != null)
        {
            monsterView.Display(combatField.PlayerMonster);
        }
        else
        {
            monsterView.Hide();
        }
    }
    private void UpdateEnemyMonster()
    {
        if (combatField.EnemyMonster != null)
        {
            enemyView.Display(combatField.EnemyMonster);
        }
        else
        {
            enemyView.Hide();
        }
    }
    private void UpdateArena()
    {
        if (combatField.Arena != null)
        {
            arenaView.Display(combatField.Arena);
        }
        else
        {
            arenaView.Hide();
        }
    }
    private void UpdatePlayer()
    {
        textPlayer.text = "Player\nHP: " + game.Player.Health + "/" + game.Player.MaxHealth+"\nEnergy: "+game.Player.Energy;
    }
}
