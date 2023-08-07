using UnityEngine;
[CreateAssetMenu(fileName = "KillBombActiveAbility", menuName = "Kill Bomb Active Ability", order = 0)]
public class KillBombActiveAbility : ActiveAbilityData
{
    [SerializeField] private Resource gold;
    public override void Use()
    {
        if (gold.CurrentAmount >= 100 && !IsActive)
        {
            IsActive = true;
            gold.CurrentAmount -= 100;
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<Enemy>().ReduceHealth(100);
            }
        }
    }
}