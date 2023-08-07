using UnityEngine;
using TMPro;
public class Gold : MonoBehaviour
{
    public Resource resource;
    public TMP_Text goldText;
    private void Start()
    {
        UpdateGoldText();
    }
    public void UpdateGoldText()
    {
        goldText.text = "Gold: " + resource.CurrentAmount.ToString();
    }
}