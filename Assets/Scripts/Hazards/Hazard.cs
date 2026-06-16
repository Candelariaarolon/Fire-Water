using UnityEngine;

public class Hazard : MonoBehaviour
{
    public LayerMask layersQueMata;
    public LayerMask layerAfin;
    public ParticleSystem particulasAfin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerDelOtro = other.gameObject.layer;

        if (((1 << layerDelOtro) & layersQueMata) != 0)
        {
            Debug.Log("Hazard mata a " + other.gameObject.name);
            LevelManager.Instance.Perder();
            return;
        }

        if (((1 << layerDelOtro) & layerAfin) != 0)
        {
            if (particulasAfin != null)
            {
                particulasAfin.gameObject.SetActive(true);
                particulasAfin.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        int layerDelOtro = other.gameObject.layer;

        if (((1 << layerDelOtro) & layerAfin) != 0)
        {
            if (particulasAfin != null)
            {
                particulasAfin.Stop();
                particulasAfin.gameObject.SetActive(false);
            }
        }
    }
}