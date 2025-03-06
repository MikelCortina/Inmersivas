using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class Collectible : MonoBehaviour
{
    public static int score = 0; // Puntuación compartida entre objetos
    public TextMeshProUGUI scoreText; // Referencia al texto del HUD

    private void Start()
    {
        UpdateScoreUI();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            score++; // Suma un punto
            UpdateScoreUI(); // Actualiza el HUD
            Destroy(gameObject); // Destruye el objeto
        }
        if (score >= 8)
        {
            UpdateScoreUIFinish();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score;
        }
      
    }
    private void UpdateScoreUIFinish()
    {
        if (scoreText != null)
        {
            scoreText.text = "Has Ganado";
        }

    }
}
