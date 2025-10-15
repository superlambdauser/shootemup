using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    private PlayerControl player;
    private PlayerShooting weapon;
    private List<EnemyBehaviour> enemies = new();
    private List<BulletBehaviour> bullets = new();
    private float enemiesSpawnCooldown;
    private float bulletsRateCooldown;
    private float bulletSpeed;
    private float chrono = 0f;


    #region Unity Events :
    private void Update()
    {
        chrono += Time.deltaTime;

        if (chrono >= enemiesSpawnCooldown)
        {
            chrono = 0f;
            EnemyBehaviour enemy = spawner.Spawn();

            if (!enemies.Contains(enemy))
            {
                enemies.Add(enemy);
                enemy.Initialize(this); // ??
            }
        }

        if (chrono >= bulletsRateCooldown )
        {
            chrono = 0f;
            weapon.Shoot();

            // if (!bullets.Contains(bullet))
            // {
            //     bullets.Add(bullet);
            //     bullet.Initialize(this, weapon, bulletSpeed);
            // }
        }

        for (int index = 0; index < bullets.Count; index++)
        {
            bullets[index].Process();
        }

        for (int index = 0; index < enemies.Count; index++)
        {
            enemies[index].Process();
        }

        player.Process();
    }
    #endregion

    #region Custom Methods
    public void Initialize(Spawner spawner, PlayerControl player, PlayerShooting weapon, float enemiesSpawnCooldown, float bulletsRateCooldown)
    {
        this.spawner = spawner;
        this.player = player;
        this.weapon = weapon;
        this.enemiesSpawnCooldown = enemiesSpawnCooldown;
        this.bulletsRateCooldown = bulletsRateCooldown;
    }

    public void EnemyFallAsleep(EnemyBehaviour enemy)
    {
        spawner.Despawn(enemy);
    }

    public void BulletFallAsleep(BulletBehaviour bullet)
    {
        weapon.Despawn(bullet);
    }
    #endregion
}
