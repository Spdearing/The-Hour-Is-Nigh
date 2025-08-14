using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;
public class RyansPlayerMovement : MonoBehaviour
{
    private float moveSpeed = 3;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] Transform cameratransform;
    public Rigidbody rb;







    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //player faces where camera is pointing
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, cameratransform.eulerAngles.y, transform.eulerAngles.z);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        //if magnitude is greater than 1 normalize it so there is not always a delay when stopping player
        if (moveDirection.magnitude > 1)
        {
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }

    }
}
