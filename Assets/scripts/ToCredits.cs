using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToCredits : MonoBehaviour
{
    public float countdownTime = 9f; // Zeit in Sekunden
    public Text countdownText;       // UI-Text für Anzeige
    public string nextSceneName = "Credits"; // Name der Zielszene

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
    }
 
    void Update()
    {
        currentTime -= Time.deltaTime;

        // Countdown anzeigen (optional)
        if (countdownText != null)
        {
            countdownText.text = Mathf.Ceil(currentTime).ToString();
        }

        // Wenn Countdown abgelaufen ist → Szene wechseln
        if (currentTime <= 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

