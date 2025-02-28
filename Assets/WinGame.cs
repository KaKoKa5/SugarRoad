using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
        [SerializeField] private GameObject player;  // Référence au joueur
     [SerializeField] private GameObject winText;
    private Vector3 offset;
    
     private bool dead = false;
   
    [SerializeField] private GameManager gameManager; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dead)
        {
            
            winText.SetActive(true); 
            Time.timeScale = 0f;
        
            EndGame();
        }
    }
    void EndGame()
    {
        dead = true;
        Time.timeScale = 0f;
         
    }
        void ReloadScene()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        
    }
}
    

