using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float crouchSpeed = 2f;
    [SerializeField] private float lookSensitivity = 0.1f;
    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float defaultHeight = 1.6f;
    [SerializeField] private float crouchHeight = 0.6f;
    [SerializeField] private bool isCrouching = false;

    private CharacterController controller;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction crouchAction;
    private float pitch;
    private float verticalSpeed;

    void Awake() {
        controller = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Player/Move");
        lookAction = InputSystem.actions.FindAction("Player/Look");
        jumpAction = InputSystem.actions.FindAction("Player/Jump");
        sprintAction = InputSystem.actions.FindAction("Player/Sprint");
        crouchAction = InputSystem.actions.FindAction("Player/Crouch");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // looking
        Vector2 look = lookAction.ReadValue<Vector2>() * lookSensitivity;
        transform.Rotate(0f, look.x, 0f);
        pitch = Mathf.Clamp(pitch - look.y, -80f, 80f);
        playerCamera.localEulerAngles = new Vector3(pitch, 0f, 0f);

        // moving
        Vector2 input = moveAction.ReadValue<Vector2>();

        float speed = walkSpeed;
        isCrouching = crouchAction.IsPressed() ? true : false;

        // crouching

        if (isCrouching) {
            controller.height = crouchHeight;
            speed = crouchSpeed;
        }
        else {
            controller.height = defaultHeight;
            speed = walkSpeed;
        }

        // sprinting

        if(sprintAction.IsPressed() && !isCrouching && input.y > 0) {
            speed = sprintSpeed;
        }
        else if (!sprintAction.IsPressed() && !isCrouching) {
            speed = walkSpeed;
        }
    
        Vector3 velocity = (transform.right * input.x + transform.forward * input.y) * speed;

        // jumping
        if(controller.isGrounded && verticalSpeed < 0f && !isCrouching)
            verticalSpeed = -2f;
        if(controller.isGrounded && jumpAction.WasPressedThisFrame() && !isCrouching)
            verticalSpeed = Mathf.Sqrt(-2f * gravity * jumpHeight);
        
        verticalSpeed += gravity * Time.deltaTime;
        velocity.y = verticalSpeed;

        controller.Move(velocity * Time.deltaTime);
    }
}
