using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;


public enum EnemyType
{
    Ghost,
    Grunt,
    Demon
}

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    public EnemyType type;

    public void TakeDamage()
    {
        health -= 1;

        if (health <= 0)
        {
            EnemyDied();
        }
    }

    void EnemyDied()
    {
        //TODO: update quest progress
        WaveManager.instance.RemoveEnemy(this.gameObject);

        foreach (DefeatQuest quest in QuestManager.instance.activeQuests)
        {
            quest.OnEnemyDefeated(type.ToString());

        }
        Destroy(gameObject);
    }
}
