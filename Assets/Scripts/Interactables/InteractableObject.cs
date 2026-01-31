using UnityEngine;
using System.Collections.Generic;
/***************
 * Interactable objects are placed in the world.
 * There should be prefabs that have this component, plus any mesh+renderer for visualization in the game, 
 *         plus a collider trigger (added automatically if forgotten)
****************/

[RequireComponent(typeof(Collider))]
/*
[System.Serializable]
public class InteractionList
{
    public List<GameAction> rangeActions;  // What actions are invoked when the player enters/leaves range of this object 
    public List<GameAction> interactActions; // What actions are invoked when the player interacts/cancels this action
}
*/

public class InteractableObject : MonoBehaviour
{    
    public DuctTapeDictionary<ChapterData, GameAction> rangeActions;
    public DuctTapeDictionary<ChapterData, GameAction> interactionActions;

    public void Start() 
    {
        //TODO: Add this to an up-to-date list in the GameManager

        // Force the collider to be a trigger
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    public void OnDestroy()
    {
        //TODO: Remove us from the up to date list in the Game Manager
    }

    public void OnTriggerEnter()
    {
        //TODO: Remember that the player is in the trigger - "make interactable"


        // Do any "entering trigger" actions - NOTE: this is not the game action ( like viewing the target )
        //        but things like "show the E to interact text" 
        // Get a list of all the game actions for the current chapter
        List<GameAction> temp = rangeActions.FindAll(GameManager.instance.currentChapter);
        // Perform them all
        foreach (GameAction action in temp) {
            action.Invoke();
        }
    }

    public void OnTriggerExit()
    {
        //TODO: Forget that the player is in the trigger - "make not interactable"
        //TODO: If an action is running, call all the "cancel" actions for that action ( so text/photo goes away when we leave trigger)
        //TODO: Do any "you left the trigger" stuff - hide the "press E" text, etc.
        // Get a list of all the game actions for the current chapter
        List<GameAction> temp = rangeActions.FindAll(GameManager.instance.currentChapter);
        // Perform them all
        foreach (GameAction action in temp) {
            action.Cancel();
        }

    }
}
