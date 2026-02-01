using UnityEngine;
using UnityEngine.InputSystem;

public class PForNextLevel : MonoBehaviour
{
    [Header("Inputs")]
    private InputAction PTest = new InputAction("P", binding: "Keyboard/p");

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PTest.Enable();
        PTest.performed += OnP;
    }

    void OnP(InputAction.CallbackContext e)
    {
        GameManager.instance.LoadNextChapter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
