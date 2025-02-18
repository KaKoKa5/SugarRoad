using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBoostTrigger : MonoBehaviour
{
    private Vector3 offset;
    public Transform cameraTransform; // Assigner la caméra dans l'Inspector

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

        if (other.CompareTag("Player"))
        {
            CameraController cameraScript = cameraTransform.GetComponent<CameraController>();
            if (cameraScript != null)
            {
                cameraScript.BoostCamera();
            }
    
        }
    }
}

