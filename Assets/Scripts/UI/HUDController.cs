using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI textoGemasRojas;
    public TextMeshProUGUI textoGemasAzules;

    void Update()
    {
        if (LevelManager.Instance == null) return;

        textoGemasRojas.text = LevelManager.Instance.GemasRojas + "/" + LevelManager.Instance.TotalGemasRojas;
        textoGemasAzules.text = LevelManager.Instance.GemasAzules + "/" + LevelManager.Instance.TotalGemasAzules;
    }
}