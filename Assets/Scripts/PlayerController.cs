using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string JUMP_BUTTON = "Jump";

    public bool isGrounded;

    private Rigidbody rb;
    public float forwardSpeed = 5f, horizontalSpeed = 5f;
    public float jumpForce;
    public float horizontalMovement;
    public float forwardMovement;

    public float groundCheckRayLength = .55f;
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
        RaycastHit[] hit = Physics.RaycastAll(transform.position, Vector3.down, groundCheckRayLength, whatIsGround);        

        if (hit != null && hit.Length > 0)
            isGrounded = true;
        else
            isGrounded = false;

        forwardMovement = forwardSpeed;
        horizontalMovement = Input.GetAxisRaw(HORIZONTAL_AXIS) * horizontalSpeed;
        float jump = 0;

        if (Input.GetButtonDown(JUMP_BUTTON))
        {
            if (isGrounded)
            {
                jump = jumpForce;
            }
        }

        rb.AddForce(new Vector3(horizontalMovement, jump * jumpForce, forwardMovement));
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckRayLength);
    }
#endif
}
