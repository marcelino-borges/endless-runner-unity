using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string JUMP_BUTTON = "Jump";

    public bool isGrounded;

    public Rigidbody rb;
    public float forwardSpeed = 5f, horizontalSpeed = 5f;
    public float jumpForce;
    public float horizontalMovement;
    public float forwardMovement;

    public Transform groundCheck
    public float groundCheckRadius = 2f;
    public LayerMask whatIsGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, whatIsGround);

        if (colliders != null && colliders.Length > 0)
            isGrounded = true;
        else
            isGrounded = false;

        forwardMovement = forwardSpeed;
        horizontalMovement = Input.GetAxisRaw(HORIZONTAL_AXIS) * horizontalSpeed;
        float jump = 0;

        if (Input.GetButtonDown(JUMP_BUTTON))
        {
            print("aaa");
            if (isGrounded)
            {
                print("Pulou");
                jump = 1;
            }
        }

        rb.AddForce(new Vector3(horizontalMovement, jump * jumpForce, forwardMovement));
        //rb.velocity += new Vector3(horizontalMovement, direction.y, direction.z);
        //charController.Move(new Vector3(horizontalMovement, direction.y, direction.z));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
