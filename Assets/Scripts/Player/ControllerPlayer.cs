using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
    [Header("Inputs")]
    public InputActionAsset inputActions;


    [Header("Do not change. In inspector for debugging Only!")]
    public List<InteractableObject> objectsInRange;


    // Awake runs before Start
    public override void Awake()
    {
        objectsInRange = new List<InteractableObject>();
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Enable my input actions
        inputActions.Enable();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // If the Interact Action Came in, 
        if (inputActions["Interact"].triggered) {
            // Go through each interactable object and tell each of their interaction actions to fire!
            foreach (InteractableObject temp in objectsInRange) {
                // Cancel all their ranged actions
                temp.RangeCancelAll();

                // Fire all their interaction actions
                temp.InteractInvokeAll();
            }
        }
        if (inputActions["Cancel"].triggered) {
            CancelAllInteractableObjects();
        }
        if (inputActions["Solve"].triggered) {
            GameManager.instance.ToggleSolveScreen();
        }

        base.Update();
    }

    public void CancelAllInteractableObjects()
    {
        // Go through each interactable object and tell each of their interaction actions to fire!
        foreach (InteractableObject temp in objectsInRange) {
            temp.InteractCancelAll(); // Run all it's cancel actions
        }
    }
}