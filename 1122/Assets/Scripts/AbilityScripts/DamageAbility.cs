using UnityEngine;

namespace AbilityScripts
{
    [CreateAssetMenu(fileName = "NewDamageAbility", menuName = "Damage Ability")]
    public class DamageAbility : AbilityData
    {
        public float abilityMultiplier = 0.1f;
        public override void SetAbilityValue()
        {
            base.SetAbilityValue();
            currentAbilityValue = baseAbilityValue +(abilityMultiplier* currentLevel) ; 
        }
    }
}