using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "RapidGunActiveAbility", menuName = "Rapid Gun Active Ability", order = 0)]
public class RapidGunActiveAbility : ActiveAbilityData
{
    [SerializeField] private Resource gold;
    public float defaultPlayerFireRate;
    private float usingDuration = 5;
    public override void Use()
    {
        if (gold.CurrentAmount >= 100 && !IsActive)
        {
            defaultPlayerFireRate = Player.fireRate;
            Player.fireRate = 0.1f;
            IsActive = true;
            gold.CurrentAmount -= 100;
        }
    }
    public override IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(usingDuration);
        Player.fireRate = defaultPlayerFireRate;
        yield return new WaitForSeconds(CooldownDuration);
        IsActive = false;
    }

    public override float GetTotalCooldownDuration()
    {
        return usingDuration + CooldownDuration;
    }
}