

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform center;
    public GameObject mainTree;
    public float radius = 10f;
    public float zoomSpeed = 5f;

    private float mouseX = 0f;
    private float mouseY = 0f;
    public WaveSpawner waveSpawner;

    public void Start()
    {
        if (waveSpawner == null)
        {
            Debug.Log("WaveSpawner is not referenced in CameraMovement.cs");
        }

        center = mainTree.transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetMouseButtonUp(1)) {
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY -= Input.GetAxis("Mouse Y");
            mouseY = Mathf.Clamp(mouseY, -89f, 89f);

            radius -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            radius = Mathf.Clamp(radius, 1f, 50f);

            Vector3 cameraPos = center.position + Quaternion.Euler(mouseY, mouseX, 0f) * Vector3.forward * radius;
            cameraPos.y = Mathf.Clamp(cameraPos.y, 4f, float.MaxValue);
            transform.position = cameraPos;
            transform.LookAt(center);
        }
    }
}
