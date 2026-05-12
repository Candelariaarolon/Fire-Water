using UnityEngine;

public class Hazard : MonoBehaviour
{
    public LayerMask layersQueMata;

    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerDelOtro = other.gameObject.layer;

        if (((1 << layerDelOtro) & layersQueMata) != 0)
        {
            Debug.Log("Hazard mata a " + other.gameObject.name);
            LevelManager.Instance.Perder();
        }
    }
}