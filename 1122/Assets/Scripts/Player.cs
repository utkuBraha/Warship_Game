using System.Collections;
using AbilityScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float lockOnDistance = 7f;
    public Transform mainFiringPoint;
    public Transform lefSideFiringPoint;
    public Transform rightSideFiringPoint;
    public AbilityData increasesAbility;
    public PowerArmAbility powerArmAbility;
    public static float fireRate = 2f;
    public bool isShooting;
    public int health = 50;
    private bool isDead;
    public static Transform lockedEnemy;
    private int defaultGoldAmount = 1000; 
    public Resource goldData;
    public void Awake()
    {
        ResetGoldToDefault();
    }
    public void ResetGoldToDefault()
    {
        goldData.CurrentAmount = defaultGoldAmount;
    }
    public void Update()
    {
        if (!isDead)
        {
            HandleMovement();
            HandleShooting();
        }
    }
    public void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();
        transform.Translate(movement * (movementSpeed * Time.deltaTime));
    }
    public void HandleShooting()
    {
        if (lockedEnemy != null && !isShooting)
        {
            StartCoroutine(AutoShoot());
        }
    }
    public IEnumerator AutoShoot()
    {
        isShooting = true;

        while (lockedEnemy != null)
        {
            var shotCount = increasesAbility.currentAbilityValue;
            
            for (int i = 0; i <shotCount ; i++)
            {
                Shoot(lockedEnemy,mainFiringPoint);
                if (powerArmAbility.isActive)
                {
                    Shoot(lockedEnemy,lefSideFiringPoint);
                    Shoot(lockedEnemy,rightSideFiringPoint);
                }
            }
            yield return new WaitForSeconds(fireRate);
        }
        isShooting = false;
    }
    public void Shoot(Transform target,Transform firingPoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();

        if (bulletComponent == null)
        {
            Destroy(bullet);
            return;
        }
        bulletComponent.SetTarget(target);
        Destroy(bullet, 2f);
    }
    public void UpdateLockedEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance <= lockOnDistance && distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
        lockedEnemy = closestEnemy;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.CompareTag("Enemy")) 
        {
            TakeDamage(5);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isDead) 
        {
            isDead = true;
            Die();
            SceneManager.LoadScene(2);
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    public void FixedUpdate()
    {
        UpdateLockedEnemy();
    }
}