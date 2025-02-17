using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveDistance = 1f; // Distance de déplacement
    public float moveSpeed = 5f; // Vitesse de déplacement

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

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
}
