using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public Color nuevoColor = Color.red;

    void Start()
    {
        GetComponent<Renderer>().material.color = nuevoColor;
    }
}
