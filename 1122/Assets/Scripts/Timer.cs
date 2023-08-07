using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float totalTime = 180f; 
    private float currentTime; 
    private TextMeshProUGUI countdownText;
    private void Start()
    {
        countdownText = GetComponent<TextMeshProUGUI>();
        currentTime = totalTime;
        StartCountdown();
    }
    private void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = Mathf.RoundToInt(currentTime).ToString();
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
    private void StartCountdown()
    {
    }
}