using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public static float damage = 5;
    private Transform target;
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); 
            return;
        }
        Vector2 direction = target.position - transform.position;
        transform.Translate(direction.normalized * (bulletSpeed * Time.deltaTime));
    }
    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}