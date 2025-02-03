using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotationSpeed;

    public float zoomSpeed = 10f;
    public float minZoom = 5f;
    public float maxZoom = 50f;
    public float smoothTime = 0.1f; 

    private float targetFOV;
    private float velocity = 0f;

    [SerializeField] private CinemachineVirtualCamera cam;

    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        targetFOV = cam.m_Lens.FieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(inputDirection != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDirection.normalized, rotationSpeed *Time.deltaTime);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        {
            if (scroll != 0)
            {
                targetFOV -= scroll * zoomSpeed;
                targetFOV = Mathf.Clamp(targetFOV, minZoom, maxZoom);
            }
            cam.m_Lens.FieldOfView = Mathf.SmoothDamp(
                cam.m_Lens.FieldOfView, targetFOV, ref velocity, smoothTime);
        }
    }

}
