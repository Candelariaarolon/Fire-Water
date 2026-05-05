using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Door doorFireboy;
    public Door doorWatergirl;
    public float tiempoParaVictoria = 2f;

    private float timerVictoria;
    private bool nivelGanado;

    void Update()
    {
        if (nivelGanado) return;

        if (doorFireboy.Ocupada && doorWatergirl.Ocupada)
        {
            timerVictoria += Time.deltaTime;

            if (timerVictoria >= tiempoParaVictoria)
            {
                Ganar();
            }
        }
        else
        {
            timerVictoria = 0f;
        }
    }

    private void Ganar()
    {
        nivelGanado = true;
        Debug.Log("¡VICTORIA! Las dos puertas estuvieron ocupadas " + tiempoParaVictoria + " segundos.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}