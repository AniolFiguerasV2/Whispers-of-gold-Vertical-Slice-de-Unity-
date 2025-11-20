using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public Color nuevoColor = Color.red; // El color que quieres

    void Start()
    {
        GetComponent<Renderer>().material.color = nuevoColor;
    }
}
