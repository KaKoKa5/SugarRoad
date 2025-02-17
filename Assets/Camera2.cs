using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public GameObject player ;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = player.transform.position + offset;
    }
      void LateUpdate()
    {
    }
}
