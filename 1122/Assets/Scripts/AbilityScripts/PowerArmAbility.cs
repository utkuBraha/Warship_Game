using UnityEngine;

namespace AbilityScripts
{
    [CreateAssetMenu(fileName = "NewPowerArmAbility", menuName = "PowerArm Ability")]
    public class PowerArmAbility : AbilityData
    {
        private void OnEnable()
        {
            isActive = false;
        }
        public bool isActive;
        public override void SetAbilityValue()
        {
            base.SetAbilityValue();
            currentAbilityValue =  currentLevel;
        }
    }
}