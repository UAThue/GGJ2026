using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeToExit : MonoBehaviour
{
    [Header("Inputs")]
    private InputAction Quit = new InputAction("Quit", binding: "Keyboard/escape");

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Quit.Enable();
        Quit.performed += OnQuit;
    }

    void OnQuit(InputAction.CallbackContext e)
    {
        Debug.Log("Quitting");
        Debug.Break(); // Pause the editor - does nothing in build
        Application.Quit(); // Quit the game - does nothing in editor
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
