using UnityEngine;

public class CicleDayNight : MonoBehaviour
{
    [Range(0.0f, 24f)]public float hour = 12f;
    public Transform light;

    public float dayDurationMinutes = 10f;

    private float lightx;

    private void Update()
    {
        hour += Time.deltaTime * (24/(60*dayDurationMinutes));

        if(hour >= 24)
        {
            hour = 0;
        }

        LightRotation();
    }
    void LightRotation()
    {
        lightx = 15 * hour;

        light.localEulerAngles = new Vector3 (lightx, 0, 0);

        if (hour < 6 || hour > 18)
        {
            light.GetComponent<Light>().intensity = 0;
        }
        else 
        {
            light.GetComponent<Light>().intensity = 0;
        }
    }
}
