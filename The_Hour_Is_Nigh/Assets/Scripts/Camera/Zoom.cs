using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    [SerializeField] private float smoothTime;

    [SerializeField] private float targetFOV;
    [SerializeField] private float velocity = 0f;

    [SerializeField] private CinemachineFreeLook cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
        targetFOV = cam.m_Lens.FieldOfView;
        zoomSpeed = 20f;
        minZoom = 5f;
        maxZoom = 100.0f;
        smoothTime = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
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
