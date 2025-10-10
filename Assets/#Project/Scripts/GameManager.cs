using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    private PlayerControl player;
    private List<EnemyBehaviour> enemies = new();
    private float cooldown;
    private float chrono = 0f;


    public void Initialize(Spawner spawner, PlayerControl player, float cooldown)
    {
        this.spawner = spawner;
        this.player = player;
        this.cooldown = cooldown;
    }

    public void EnemyFallAsleep(EnemyBehaviour enemy)
    {
        spawner.Despawn(enemy);
    }


    private void Update()
    {
        chrono += Time.deltaTime;

        if (chrono >= cooldown)
        {
            chrono = 0f;
            EnemyBehaviour enemy = spawner.Spawn();

            if (!enemies.Contains(enemy))
            {
                enemies.Add(enemy);
                enemy.Initialize(this); // ??
            }
        }

        for (int index = 0; index < enemies.Count; index++)
        {
            enemies[index].Process();
        }

        player.Process();
    }
}
