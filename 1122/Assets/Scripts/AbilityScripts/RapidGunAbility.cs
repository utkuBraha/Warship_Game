using UnityEngine;

namespace AbilityScripts
{
    [CreateAssetMenu(fileName = "NewGunAbility", menuName = "RapidGun Ability")]
    public class RapidGunAbility : AbilityData
    {
        public override void SetAbilityValue()
        {
            base.SetAbilityValue();
            currentAbilityValue =  currentLevel ; 
        }
    }
}