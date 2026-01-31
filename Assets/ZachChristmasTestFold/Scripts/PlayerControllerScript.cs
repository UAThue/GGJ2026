
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{
    [Header("Player Movement Variables")]

    PlayerInput pInput; //Reference to the player input system

    InputAction horizontalInputPI; //Input for the horizontal axis
    InputAction verticalInputPI; //Input for the vertical axis

    float horizontalInput; //Reference to the players horizontal input [x axis]
    float verticalInput; //Reference to the player vertical input [z axis]

    public float playerSpeed; //Speed of the player

    Rigidbody rb; //Player rigidbody

    [Header("Mouse Rotation")]

    [SerializeField] float xRot; //X and Y rotation of the current camera
    [SerializeField] float yRot;

    [SerializeField] float camSensitivity; //Sensitivity of the camera

    [SerializeField] GameObject camObject; //Camera object that they player will be rotating

    private void Awake()
    {
        pInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        //Set the player inputs
        horizontalInputPI = pInput.actions["Horizontal"];
        verticalInputPI = pInput.actions["Vertical"];

    }

    //On value changes
    void OnInputFieldValueChanged()
    {
        horizontalInput = horizontalInputPI.ReadValue<float>();
        verticalInput = verticalInputPI.ReadValue<float>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        horizontalInput = horizontalInputPI.ReadValue<float>();
        verticalInput = verticalInputPI.ReadValue<float>();


        rb.linearVelocity = transform.TransformDirection(new Vector3(horizontalInput * playerSpeed, rb.linearVelocity.y, verticalInput * playerSpeed));

        //Camera Rotation and Control

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * camSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * camSensitivity;

        yRot += mouseX;

        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot, -90f, 90);

        camObject.transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);


    }


    


}
