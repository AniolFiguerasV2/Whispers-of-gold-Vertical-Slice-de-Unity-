using UnityEngine;

public class DayCicle : MonoBehaviour
{
    public float dayDuration = 10f;
    public Light directionalLight;

    private float cycleTime = 0f;
    private const float gameHours = 12f;
    public float startRotation = 100f;

    private bool gameEnded = false;

    void Start()
    {
        if (directionalLight == null)
            directionalLight = GetComponent<Light>();
    }

    void Update()
    {
        if (gameEnded) return;

        float hoursPerSecond = gameHours / (dayDuration * 60f);
        cycleTime += hoursPerSecond * Time.deltaTime;

        float normalizedTime = cycleTime / gameHours;

        float rotation = startRotation + normalizedTime * 360f;

        directionalLight.transform.rotation = Quaternion.Euler(rotation, 170f, 0f);

        if (cycleTime >= gameHours)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;

        Application.Quit();
    }
}
