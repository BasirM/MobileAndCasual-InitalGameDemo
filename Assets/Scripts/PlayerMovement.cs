using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    public float cameraXOffset = 7.5f;
    public float cameraYOffset = 7.5f;
    public float cameraZOffset = -0.5f;
    Vector3 offset;
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraStartPos = new Vector3(cameraXOffset,cameraYOffset,cameraZOffset);
        mainCamera.transform.position = cameraStartPos;
        offset = mainCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = transform.position + offset;
        //Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.deltaTime, ForceMode.VelocityChange);

        if (fixedJoystick.Horizontal >= .2f)
        {
            horizontalMove = speed;
        }
        else if (fixedJoystick.Horizontal <= -.2f)
        {
            horizontalMove = -speed;
        }
        else
        {
            horizontalMove = 0f;
        }

        if (fixedJoystick.Vertical >= .2f)
        {
            verticalMove = speed;
        }
        else if (fixedJoystick.Horizontal <= -.2f)
        {
            verticalMove = -speed;
        }
        else
        {
            verticalMove = 0f;
        }


        rb.AddForce(new Vector3(horizontalMove, 0.0f, verticalMove));
    }

}
