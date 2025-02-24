using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f; // Distance de déplacement
    [SerializeField] private float moveSpeed = 5f; // Vitesse de déplacement

    private Vector3 targetPosition;
    private bool isMoving = false;
    private int count;

    [SerializeField] private GameObject winText;
    [SerializeField] private TextMeshProUGUI contText;


    void Update()
    {
        if (!isMoving) // Vérifie si le joueur peut bouger
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
                Move(Vector3.forward);
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                Move(Vector3.back);
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
                Move(Vector3.left);
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                Move(Vector3.right);
        }

        // Déplacement fluide du joueur vers la position cible
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Vérifie si le joueur a atteint la position cible
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            isMoving = false;
        }
    }

    void Move(Vector3 direction)
    {
        targetPosition += direction * moveDistance;
        isMoving = true;
    }
    
    //Modif Saverio pour le score 
    
    void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            count=count+1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        contText.text = "Score : "+ Input.GetKeyDown(KeyCode.UpArrow);
        
    }
    void Start()
    {
        targetPosition = transform.position;
        count = 0;
        SetCountText();
        winText.SetActive(false);

    }
}
