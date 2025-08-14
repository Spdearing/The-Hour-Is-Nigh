using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstPersonCamera : MonoBehaviour
{
    public float lookspeed;
    public GameObject player;

    private float _yaw;
    private float _pitch;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _yaw += lookspeed * Input.GetAxis("Mouse X");
        _pitch -= lookspeed * Input.GetAxis("Mouse Y");

        _pitch = Mathf.Clamp(_pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(_pitch, _yaw, 0);

        //camera stays with player but is not child of player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .6f, player.transform.position.z);
    }
}
