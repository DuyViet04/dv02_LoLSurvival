using UnityEngine;

public class BossSpawner : SpawnerSingleton<BossSpawner>
{
    Vector3 spawnPosition = new Vector3(60, 0, 60);
    private float timer = 0f;

    private void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= 15 * 60f)
        {
            this.Spawn("BossAatrox", this.spawnPosition, Quaternion.identity, 1);
            this.timer = 0f;
        }
    }
}