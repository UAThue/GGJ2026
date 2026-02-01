using UnityEngine;
using System.Collections.Generic;
/***************
 * Interactable objects are placed in the world.
 * There should be prefabs that have this component, plus any mesh+renderer for visualization in the game, 
 *         plus a collider trigger (added automatically if forgotten)
****************/

[RequireComponent(typeof(Collider))]
public class InteractableObject : MonoBehaviour
{    
    public DuctTapeDictionary<ChapterData, GameAction> rangeActions;
    public DuctTapeDictionary<ChapterData, GameAction> interactionActions;

    public void Start() 
    {
        //MAYBE: Add this to an up-to-date list in the GameManager

        // Force the collider to be a trigger
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    public void OnDestroy()
    {
        //MAYBE: Remove us from the up to date list in the Game Manager
    }

    public void InteractInvokeAll()
    {
        Debug.Log(gameObject.name + " is attempting to perform actions for " + GameManager.instance.currentChapter.displayName);

        // Get the list of all interaction actions for this chapter
        List<GameAction> temp = interactionActions.FindAll(GameManager.instance.currentChapter);

        // Cancel if no actions
        if (temp == null)
        {
            Debug.Log(gameObject.name + " has no interaction actions for " + GameManager.instance.currentChapter.displayName);
            return;
        }

        // Perform them all
        foreach (GameAction action in temp) {
            if (action != null) {
                if (!action.isActive) {
                    Debug.Log("Performing action: " + action.name);
                    action.Invoke();
                }
            }
        }
    }
    public void InteractCancelAll()
    {
        // Get the list of all interaction actions for this chapter
        List<GameAction> temp = interactionActions.FindAll(GameManager.instance.currentChapter);
        
        // Cancel if no actions
        if (temp == null) return;

        // Perform them all
        if (temp.Count > 0) {
            foreach (GameAction action in temp) {
                if (action != null) {
                    if (action.isActive) {
                        action.Cancel();
                    }
                }
            }
        }
    }

    public void RangeInvokeAll()
    {
        // Do any "entering trigger" actions - NOTE: this is not the game action ( like viewing the target )
        //        but things like "show the E to interact text" 
        // Get a list of all the game actions for the current chapter
        List<GameAction> temp = rangeActions.FindAll(GameManager.instance.currentChapter);

        // Cancel if no actions
        if (temp == null) return;

        // Perform them all
        if (temp.Count > 0) {
            foreach (GameAction action in temp) {
                // Only invoke actions that aren't already invoked!
                if (!action.isActive) {
                    action.Invoke();
                }
            }
        }
    }

    public void RangeCancelAll()
    {
        //Call the "cancel" actions for this action ( so text/photo goes away when we leave trigger)
        List<GameAction> temp = rangeActions.FindAll(GameManager.instance.currentChapter);

        // Cancel if no actions
        if (temp == null) return;

        // Perform them all
        foreach (GameAction action in temp) {
            // If running, cancel it - don't cancel things that aren't running
            if (action.isActive) {
                action.Cancel();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check if the other has a Pawn component
        if (other.GetComponent<Pawn>() != null) {

            // Remember that the player is in the trigger by adding to player's list of objects in range
            GameManager.instance.player.objectsInRange.Add(this);

            // Call all the "enter range" actions
            RangeInvokeAll();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // Check if the other has a Pawn component
        if (other.GetComponent<Pawn>() != null) {

            // Turn off any active actions
            InteractCancelAll();
            RangeCancelAll();

            // Forget that the player is in the trigger by adding to player's list of objects in range
            GameManager.instance.player.objectsInRange.Remove(this);
        }
    }
}
