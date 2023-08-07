using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Active Ability", menuName = "Active Ability")]
[System.Serializable]
public class ActiveAbilityData : ScriptableObject
{
    private int cooldownDuration = 10;
    public bool IsActive { get; set; }
    private void OnEnable()
    {
        IsActive = false;
    }
    public int CooldownDuration
    {
        get => cooldownDuration;
        set => cooldownDuration = value;
    }
    public virtual void Use()
    {
    }
    public virtual float GetTotalCooldownDuration()
    {
        return cooldownDuration;
    }
    public virtual IEnumerator Cooldown()
    {
        IsActive = true;
        yield return new WaitForSeconds(CooldownDuration);
        IsActive = false;
    }
}