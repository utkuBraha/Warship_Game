using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnEnemies : MonoBehaviour
{
    public float spawnInterval = 3f;
    [SerializeField] 
    private List<EnemyData> enemiesData = new List<EnemyData>();
    [SerializeField] 
    private Resource gold;
    private Transform playerTransform;
    public float intervalDecreaseAmount = 0.2f;
    public float minSpawnInterval = 0.5f;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            spawnInterval -= intervalDecreaseAmount; 
            spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval); 
            SpawnRandomEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private void SpawnRandomEnemy()
    {
        Vector2 playerPosition = playerTransform.position;
        float spawnRange = 10f;
        Vector2 enemySpawn = new Vector2(Random.Range(playerPosition.x - spawnRange, playerPosition.x + spawnRange), 
            Random.Range(playerPosition.y - spawnRange, playerPosition.y + spawnRange));
        EnemyData selectedEnemyData = enemiesData[Random.Range(0, enemiesData.Count)];
        GameObject spawnedEnemy =Instantiate(selectedEnemyData.EnemyPrefab, enemySpawn, Quaternion.identity);
        spawnedEnemy.GetComponent<Enemy>().enemyData = selectedEnemyData;
        spawnedEnemy.GetComponent<Enemy>().goldData = gold;
    }
}