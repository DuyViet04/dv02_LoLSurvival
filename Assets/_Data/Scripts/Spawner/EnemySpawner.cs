using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    public static EnemySpawner Instance => instance;

    [SerializeField] private CSDisplay display;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float spawnRange = 5f;
    private float spawnTimer = 0f;
    private string meleeEnemy = "MeleeEnemy";

    private void Awake()
    {
        if (instance != null) Debug.LogError("There is more than one Spawner in the scene!");
        instance = this;

        this.LoadPrefabs();
    }

    private void Update()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnTime) return;
        this.spawnTimer = 0f;
        Spawn(this.meleeEnemy, this.GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(this.spawnRange, -this.spawnRange);
        float z = Random.Range(this.spawnRange, -this.spawnRange);
        return new Vector3(x, 0, z);
    }

    public override void Despawn(Transform prefab)
    {
        base.Despawn(prefab);
        this.display.IncreaseCsCount();
    }
}