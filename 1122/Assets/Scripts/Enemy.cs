using UnityEngine;
public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    private int currentHealth;
    private Transform playerTransform;
    public int damageToPlayer = 5;
    public int enemyType ; 
    public int goldReward = 10;
    private float timer;
    public Resource goldData;
    private void Start()
    {
        currentHealth = enemyData.health;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = playerTransform.position - transform.position;
            transform.Translate(direction.normalized * (enemyData.speed * Time.deltaTime));
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= Mathf.RoundToInt(damage);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        GiveGoldToPlayer();
    }
    private void GiveGoldToPlayer()
    {
        goldData.CurrentAmount += goldReward;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damageToPlayer);
            Destroy(gameObject);
        }
    }
    public void ReduceHealth(int damageAmount)
    {
        enemyData.currentHealth -= damageAmount;

        if (enemyData.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}