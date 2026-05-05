using UnityEngine;

public class Door : MonoBehaviour
{
    public LayerMask layerEsperado;

    public bool Ocupada { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (EsElPersonajeEsperado(other))
        {
            Ocupada = true;
            Debug.Log(gameObject.name + " ocupada por " + other.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (EsElPersonajeEsperado(other))
        {
            Ocupada = false;
            Debug.Log(gameObject.name + " desocupada (salió " + other.gameObject.name + ")");
        }
    }

    private bool EsElPersonajeEsperado(Collider2D other)
    {
        int layerDelOtro = other.gameObject.layer;
        return ((1 << layerDelOtro) & layerEsperado) != 0;
    }
}