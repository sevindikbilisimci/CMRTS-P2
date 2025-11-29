using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;

    [SerializeField]
    float moveSpeed = 3f;
    public float rotationSpeed = 10f;
    Vector3 velocity;
    public float jumpHeight = 2f;

    public Transform cameraTransform;

    [SerializeField] Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 yon = new Vector3(h,0f,v).normalized;
        

        if(yon.x != 0f || yon.z != 0f)
        {
            animator.SetBool("isWalking", true);

            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            moveDir = (camForward * yon.z + camRight * yon.x).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * -9.81f);
        }

        velocity.y += -9.81f * Time.deltaTime;

        moveDir = moveDir * moveSpeed;

        Vector3 finalMove = moveDir + velocity;

        controller.Move(finalMove * Time.deltaTime);

    }

   
}
