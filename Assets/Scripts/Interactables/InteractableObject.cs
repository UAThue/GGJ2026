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

    public void OnTriggerEnter(Collider other)
    {
        // Check if the other has a Pawn component
        if (other.GetComponent<Pawn>() != null) {

            // Remember that the player is in the trigger by adding to player's list of objects in range
            GameManager.instance.player.objectsInRange.Add(this);

            // Do any "entering trigger" actions - NOTE: this is not the game action ( like viewing the target )
            //        but things like "show the E to interact text" 
            // Get a list of all the game actions for the current chapter
            List<GameAction> temp = rangeActions.FindAll(GameManager.instance.currentChapter);
            // Perform them all
            foreach (GameAction action in temp) {
                action.Invoke();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // Check if the other has a Pawn component
        if (other.GetComponent<Pawn>() != null) {

            // Forget that the player is in the trigger by adding to player's list of objects in range
            GameManager.instance.player.objectsInRange.Remove(this);

            //Call the "cancel" actions for this action ( so text/photo goes away when we leave trigger)
            List<GameAction> temp = rangeActions.FindAll(GameManager.instance.currentChapter);
            // Perform them all
            foreach (GameAction action in temp) {
                action.Cancel();
            }
        }
    }
}
