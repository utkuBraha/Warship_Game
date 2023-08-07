using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActiveAbilityController : MonoBehaviour
{
    public ActiveAbilityData activeAbilityData;
    public TextMeshProUGUI countdownText;
    private Coroutine countdownCoroutine;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(UseAbility);
    }
    private void UseAbility()
    {
        if (activeAbilityData.IsActive) return;
        activeAbilityData.Use();
        StartCoroutine(activeAbilityData.Cooldown());
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = StartCoroutine(StartCountdown(activeAbilityData.GetTotalCooldownDuration()));
    }
    private IEnumerator StartCountdown(float countDownDuration)
    {
        float remainingTime = countDownDuration;

        while (remainingTime > 0f)
        {
            int mins = Mathf.FloorToInt(remainingTime / 60);
            int secs = Mathf.FloorToInt(remainingTime % 60);

            countdownText.text = "Countdown : " + string.Format("{0:00}:{1:00}", mins, secs);

            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        countdownText.text = "Countdown : 00:00";
    }
}