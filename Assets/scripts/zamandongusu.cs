using UnityEngine;
using UnityEngine.UI; // UI i�lemleri i�in gerekli

public class zamandongusu : MonoBehaviour
{
    public Light directionalLight;
    public float dayDuration = 250f;
    public float nightDuration = 250f;
    public Text dayCounterText; // G�n say�s�n� g�stermek i�in bir UI Text bile�eni

    private float totalCycleDuration;
    private float currentTime = 0f;
    private int dayCounter = 0; // G�n sayac�

    void Start()
    {
        totalCycleDuration = dayDuration + nightDuration;

        // Ba�lang��ta UI �zerinde g�n say�s�n� g�ster
        UpdateDayCounterUI();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        // D�ng� tamamland���nda g�n sayac�n� art�r
        if (currentTime >= totalCycleDuration)
        {
            currentTime = 0f;
            dayCounter++; // G�n say�s�n� art�r
            UpdateDayCounterUI(); // UI'yi g�ncelle
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
            dayCounterText.text = "G�n: " + dayCounter;
        }
        else
        {
            Debug.LogWarning("Day Counter Text is not assigned in the inspector.");
        }
    }
}
