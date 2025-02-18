using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    public float speed = 5f;
    public float BoostSpeed = 10f;
    public float TimeBoost = 0.5f;

    private float CurrentSpeed;
    private bool isBoosting = false;

    private void Start()
    {
        CurrentSpeed = speed;
    }

    private void Update()
    {
        // Utilisation de CurrentSpeed au lieu de speed pour prendre en compte le boost
        transform.position += Vector3.forward * CurrentSpeed * Time.deltaTime;
    }

    public void BoostCamera()
    {
        if (!isBoosting)
        {
            StartCoroutine(BoostCoroutine());
        }
    }

    private System.Collections.IEnumerator BoostCoroutine()
    {
        isBoosting = true;
        CurrentSpeed = BoostSpeed; // Active le boost
        yield return new WaitForSeconds(TimeBoost);
        CurrentSpeed = speed; // Remet la vitesse normale
        isBoosting = false;
    }
}
