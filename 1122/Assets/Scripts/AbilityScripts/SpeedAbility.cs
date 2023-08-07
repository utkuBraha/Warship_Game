using UnityEngine;

namespace AbilityScripts
{
    [CreateAssetMenu(fileName = "NewSpeedAbility", menuName = "Speed Ability")]
    public class SpeedAbility : AbilityData
    {
        public float abilityDecrease = 0.1f; 
        public override void SetAbilityValue()
        {
            base.SetAbilityValue();
            currentAbilityValue = baseAbilityValue +(currentLevel - abilityDecrease ) ; 
        }
    }
}