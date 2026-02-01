using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GA_", menuName = "GameActions/ShowInteract", order = 1)]
public class GA_Interact : GameAction
{
    [Header("Data")]
    public string interactionName;
    public string interactionText = "Press E to Interact";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public override void Invoke()
    {
        // Show the text
        UIManager.instance.ShowInteractionText(interactionName, interactionText);

        // Do the parent version -- which includes calling the UnityEvent-based additions
        base.Invoke();
    }

    public override void Cancel()
    {
        // Hide the text
        UIManager.instance.HideInteractionText();

        // Do the parent version -- which includes calling the UnityEvent-based additions
        base.Cancel();
    }
}
