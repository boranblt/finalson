using UnityEngine;
using UnityEngine.UI; // UI iþlemleri için gerekli

public class zamandongusu : MonoBehaviour
{
    public Light directionalLight;
    public float dayDuration = 250f;
    public float nightDuration = 250f;
    public Text dayCounterText; // Gün sayýsýný göstermek için bir UI Text bileþeni

    private float totalCycleDuration;
    private float currentTime = 0f;
    private int dayCounter = 0; // Gün sayacý

    void Start()
    {
        totalCycleDuration = dayDuration + nightDuration;

        // Baþlangýçta UI üzerinde gün sayýsýný göster
        UpdateDayCounterUI();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        // Döngü tamamlandýðýnda gün sayacýný artýr
        if (currentTime >= totalCycleDuration)
        {
            currentTime = 0f;
            dayCounter++; // Gün sayýsýný artýr
            UpdateDayCounterUI(); // UI'yi güncelle
        }

        float cycleProgress = currentTime / totalCycleDuration;
        float sunAngle = Mathf.Lerp(0f, 360f, cycleProgress);

        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(sunAngle - 90f, 170f, 0f));

        UpdateLighting(cycleProgress);
    }

    void UpdateLighting(float cycleProgress)
    {
        if (cycleProgress < 0.5f)
        {
            float intensity = Mathf.Lerp(0.1f, 1f, cycleProgress * 2);
            RenderSettings.ambientIntensity = intensity;
            directionalLight.intensity = intensity;
        }
        else
        {
            float intensity = Mathf.Lerp(1f, 0.1f, (cycleProgress - 0.5f) * 2);
            RenderSettings.ambientIntensity = intensity;
            directionalLight.intensity = intensity;
        }
    }

    void UpdateDayCounterUI()
    {
        if (dayCounterText != null)
        {
            dayCounterText.text = "Gün: " + dayCounter;
        }
        else
        {
            Debug.LogWarning("Day Counter Text is not assigned in the inspector.");
        }
    }
}
