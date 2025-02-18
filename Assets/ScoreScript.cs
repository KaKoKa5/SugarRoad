using UnityEngine;
using UnityEngine.UI;  // Pour manipuler l'UI (Text)

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Texte affichant le score
    public Text highScoreText;  // Texte affichant le high score
    public GameObject player;  // Référence au joueur

    private int score = 0;
    private int highScore = 0;
    private float playerStartZ;  // Position Z du joueur au début

    void Start()
    {
        playerStartZ = player.transform.position.z;

        // Charge le high score précédemment sauvegardé
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }

    void Update()
    {
        // Augmente le score en fonction de la position du joueur
        int newScore = Mathf.FloorToInt(player.transform.position.z - playerStartZ);
        if (newScore > score)
        {
            score = newScore;
            UpdateScoreUI();
        }

        // Sauvegarder le high score si nécessaire
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);  // Sauvegarde le high score
            PlayerPrefs.Save();  // Sauvegarde immédiatement
        }
    }

    void UpdateScoreUI()
    {
        // Met à jour les textes pour afficher le score et le high score
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
