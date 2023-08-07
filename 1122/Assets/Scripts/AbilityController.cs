using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AbilityController : MonoBehaviour
{
    [SerializeField] private AbilityData abilityData;
    [SerializeField] private TMP_Text levelText;
    public TextMeshProUGUI skillHud;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
        UpdateTexts();
    }
    private void UpdateTexts()
    {
        levelText.text = (abilityData.currentLevel == abilityData.maxLevel)
            ? "Max Level"
            : "Level: " + abilityData.currentLevel;
        skillHud.text = $"{abilityData.name} = {abilityData.currentAbilityValue}";
    }
    private void OnButtonClicked()
    {
        if (abilityData.currentLevel < abilityData.maxLevel)
        {
            abilityData.Upgrade();
            UpdateTexts();
        }
    }
}