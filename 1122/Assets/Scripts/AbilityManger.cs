using AbilityScripts;
using UnityEngine;
public class AbilityManager : MonoBehaviour
{
    public PowerArmAbility powerArmAbility;
    public GameObject poweredArmsObj;
    public Resource goldData;
    public void Awake()
    {
        powerArmAbility.currentLevel = 0;
    }
    public void PowerArm()
    {
        if (!powerArmAbility.isActive && goldData.CurrentAmount >= 100)
        {
            poweredArmsObj.SetActive(true);
            goldData.CurrentAmount -= 100;
            powerArmAbility.isActive = true;
        }
    }
}