using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string JUMP_BUTTON = "Jump";

    private Rigidbody rb;
    public LayerMask whatIsGround;
    public Animator animator;
    public Controls controlsUI;
    public bool isGrounded;
    public float currentForwardSpeed = 300f;
    public float maxForwardSpeed = 300f;
    public float horizontalSpeed = 800f;
    public float jumpForce;
    public float horizontalMovement;
    public float groundCheckRayLength = .55f;
    private bool isRunning = false;
    private bool jump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Stop();
    }

    void FixedUpdate()
    {
        //Ground check
        RaycastHit[] hit = Physics.RaycastAll(transform.position, Vector3.down, groundCheckRayLength, whatIsGround);

        if (hit != null && hit.Length > 0)
            isGrounded = true;
        else
            isGrounded = false;

        //Side moviments
#if UNITY_EDITOR || UNITY_STANDALONE
        Move((int)(Input.GetAxisRaw(HORIZONTAL_AXIS)));
#endif
        //If game is not over
        if (!LevelManager.instance.isGameOver)
        {
            //If jump button is pressed
            if (Input.GetButtonDown(JUMP_BUTTON))
            {
                //If player is grounded
                if (isGrounded)
                {
                    //Sets to jump
                    jump = true;
                }
            }

            //If is not running
            if (!isRunning)
                //if horizontal/vertical movement keys are pressed
                if (Input.GetButtonDown(HORIZONTAL_AXIS) || Input.GetButtonDown(VERTICAL_AXIS))
                    Run();

            //Sets all movement values to the rigidbody's velocity
            //If jump is true, sets velocity Y to jumpForce, otherwise sets to the current rb Y velocity
            rb.velocity = new Vector3(horizontalMovement, jump ? jumpForce : rb.velocity.y, currentForwardSpeed);
        }
        //Resets jump value
        jump = false;
    }

    /// <summary>
    /// Stops the player
    /// </summary>
    private void Stop()
    {
        isRunning = false;
        Move(0);
        rb.velocity = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Sets the player to run and calls it's respective animation
    /// </summary>
    public void Run()
    {
        isRunning = true;
        animator.SetTrigger("run");
        currentForwardSpeed = maxForwardSpeed;
    }

    /// <summary>
    /// Stops the player and calls the death animation
    /// </summary>
    public void Die()
    {
        Stop();
        animator.SetTrigger("die");
        LevelManager.instance.GameOver();

        if (controlsUI != null)
            controlsUI.DeactivateButtons();
    }

    /// <summary>
    /// Moves the player according to the direction passed
    /// </summary>
    /// <param name="direction">-1 left, 0 stop, 1 right</param>
    public void Move(int direction)
    {
        horizontalMovement = direction * horizontalSpeed;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Simulating the raycast line for ground check
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckRayLength);
    }
#endif
}
