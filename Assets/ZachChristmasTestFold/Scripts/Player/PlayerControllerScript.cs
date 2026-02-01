
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


    [Header("Logbook UI Stuff")]
    bool IsBookOpen;

    [SerializeField] GameObject LogbookUI;

    private void Awake()
    {
        //gets the primary components needed for the player
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
        //Closes the logbook on start and locks the mouse
        LogbookUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Will Check to see if the player can open the logbook
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseBook();
        }

        //prevents the players movement if the book is open
        if (!IsBookOpen)
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


    void OpenCloseBook()
    {
        if (IsBookOpen)
        {
            LogbookUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            IsBookOpen = false;
        }
        else
        { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LogbookUI.SetActive(true);
            LogbookUI.GetComponent<LogBookControl>().OpenBook();
            IsBookOpen = true;
        }
    }
}
