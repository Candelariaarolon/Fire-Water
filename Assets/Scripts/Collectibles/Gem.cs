using UnityEngine;

public class Gem : MonoBehaviour
{
    public LayerMask layerEsperado;

    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerDelOtro = other.gameObject.layer;

        if (((1 << layerDelOtro) & layerEsperado) != 0)
        {
            Debug.Log("Gema " + gameObject.name + " recolectada por " + other.gameObject.name);
            LevelManager.Instance.SumarGema(gameObject);
            AudioManager.Instance.PlayGem();
            Destroy(gameObject);
        }
    }
}