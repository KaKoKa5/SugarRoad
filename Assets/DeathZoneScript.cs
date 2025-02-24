using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;  // Référence au joueur
     [SerializeField] private GameObject restartText;
    private Vector3 offset;
    
    [SerializeField] private Transform cameraTransform; // Assigner la caméra dans l'Inspector
     private bool dead = false;
   
    [SerializeField] private float Reload;
    [SerializeField] private GameManager gameManager; 

 private void Start()
    {
        offset = transform.position - cameraTransform.position;
        restartText.SetActive(false);
    }

    private void Update()
    {
        transform.position = cameraTransform.position + offset;
    }
      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dead)
        {
            
            restartText.SetActive(true); 
            Time.timeScale = 0f;
        
            EndGame();
        }
    }

    void EndGame()
    {
        dead = true;
        Time.timeScale = 1f;
         
    }

    void ReloadScene()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}

