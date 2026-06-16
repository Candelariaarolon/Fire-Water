using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public Door doorFireboy;
    public Door doorWatergirl;
    public float tiempoParaVictoria = 2f;

    public GameObject panelDerrota;
    public GameObject panelVictoria;
    public TextMeshProUGUI textoGemasVictoria;

    private float timerVictoria;
    private bool nivelTerminado;

    public int GemasRojas { get; private set; }
    public int GemasAzules { get; private set; }
    public int TotalGemasRojas { get; private set; }
    public int TotalGemasAzules { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ContarGemasIniciales();
    }

    void Update()
    {
        if (nivelTerminado) return;

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

    public void SumarGema(GameObject gema)
    {
        if (gema.name.ToLower().Contains("red"))
        {
            GemasRojas++;
            Debug.Log("Gemas rojas: " + GemasRojas + "/" + TotalGemasRojas);
        }
        else if (gema.name.ToLower().Contains("blue"))
        {
            GemasAzules++;
            Debug.Log("Gemas azules: " + GemasAzules + "/" + TotalGemasAzules);
        }
    }

    public void Perder()
{
    if (nivelTerminado) return;
    nivelTerminado = true;

    Debug.Log("¡DERROTA!");
    AudioManager.Instance.PlayDeath();
    panelDerrota.SetActive(true);
    Time.timeScale = 0f;
}

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ContarGemasIniciales()
    {
        Gem[] todasLasGemas = FindObjectsByType<Gem>(FindObjectsSortMode.None);

        foreach (Gem gema in todasLasGemas)
        {
            if (gema.name.ToLower().Contains("red"))
            {
                TotalGemasRojas++;
            }
            else if (gema.name.ToLower().Contains("blue"))
            {
                TotalGemasAzules++;
            }
        }

        Debug.Log("Total de gemas — Rojas: " + TotalGemasRojas + " | Azules: " + TotalGemasAzules);
    }

    private void Ganar()
{
    nivelTerminado = true;

    Debug.Log("¡VICTORIA! Gemas rojas: " + GemasRojas + "/" + TotalGemasRojas + " | Gemas azules: " + GemasAzules + "/" + TotalGemasAzules);

    AudioManager.Instance.PlayVictory();
    textoGemasVictoria.text = "Gemas rojas: " + GemasRojas + "/" + TotalGemasRojas + "\nGemas azules: " + GemasAzules + "/" + TotalGemasAzules;
    panelVictoria.SetActive(true);
    Time.timeScale = 0f;
}
}