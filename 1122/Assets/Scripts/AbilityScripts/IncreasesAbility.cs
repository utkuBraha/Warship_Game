using UnityEngine;

namespace AbilityScripts
{
    [CreateAssetMenu(fileName = "NewShotsAbility", menuName = "Shots Ability")]
    public class IncreasesAbility : AbilityData
    {
        public override void SetAbilityValue()
        {
            base.SetAbilityValue();
            currentAbilityValue =  currentLevel ; 
        }
    }
}