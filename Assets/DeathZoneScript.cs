using UnityEngine;
using UnityEngine.SceneManagement;  // Pour recharger la scène


public class EndGameTrigger : MonoBehaviour
{
    public GameObject player;  // Référence au joueur
    private Vector3 offset;
    public Transform cameraTransform; // Assigner la caméra dans l'Inspector
     private bool gameOver = false;
     public float Reload;


 private void Start()
    {
        offset = transform.position - cameraTransform.position;
    }

    private void Update()
    {
        transform.position = cameraTransform.position + offset;
    }
      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameOver)
        {
            Debug.Log("Fin de Partie : Trigger touché !");
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;
        // Afficher un message de fin de partie (facultatif)
        // Par exemple, tu peux activer une UI de Game Over ici

        // Recharger la scène après 2 secondes (par exemple)
        Invoke("ReloadScene", Reload);
    }

    void ReloadScene()
    {
        // Recharge la scène actuelle (redémarre le jeu)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

