using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    public int health = 15; 
    public float speed = 2f;
    public int currentHealth;
    public GameObject EnemyPrefab => enemyPrefab;
    public void ReduceHealth(int value)
    {
        health -= value;
    }
}