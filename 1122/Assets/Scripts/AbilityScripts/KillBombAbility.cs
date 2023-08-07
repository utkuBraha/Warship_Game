using UnityEngine;

namespace AbilityScripts
{
    [CreateAssetMenu(fileName = "NewBombAbility", menuName = "KillBomb Ability")]
    public class KillBombAbility : AbilityData
    {
        public override void SetAbilityValue()
        {
            base.SetAbilityValue();
            currentAbilityValue =  currentLevel; 
        }
    }
}