using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minZoom = 5f;
    public float maxZoom = 50f;
    public float smoothTime = 0.1f;

    private float targetFOV;
    private float velocity = 0f;

    [SerializeField] private CinemachineFreeLook cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
        targetFOV = cam.m_Lens.FieldOfView;

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
