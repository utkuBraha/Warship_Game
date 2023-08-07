using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "ScriptableObjects/Ability")]
[System.Serializable]
public class AbilityData : ScriptableObject
{
    public int baseCost;
    public int currentLevel;
    public int maxLevel;
    public float currentAbilityValue;
    public float baseAbilityValue;
    public Resource goldData;
    public void OnEnable()
    {
        currentLevel = 1;
        currentAbilityValue = baseAbilityValue;
    }
    public void Upgrade()
    {
        if (goldData.CurrentAmount < baseCost) return;
        goldData.CurrentAmount -= baseCost;
        currentLevel++;
        SetAbilityValue();
    }
    public virtual void SetAbilityValue()
    {
    }
}