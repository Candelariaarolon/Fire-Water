using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    public LayerMask layersQueMata;

    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerDelOtro = other.gameObject.layer;

        if (((1 << layerDelOtro) & layersQueMata) != 0)
        {
            Debug.Log("Hazard mata a " + other.gameObject.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}