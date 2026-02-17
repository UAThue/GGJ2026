using UnityEngine;
using System.Collections.Generic;

public enum teleportLocations { toOffice, fromOffice, toBasement, fromBasement, toBathroom, fromBathroom, toBackHall, fromBackhall}

[CreateAssetMenu(fileName = "GA_", menuName = "GameActions/TeleportAction", order = 1)]
public class GA_Teleport : GameAction
{
    [Header("Visuals")]
    public teleportLocations targetLocation;


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
        // Hide any interaction text that might be visible
        UIManager.instance.HideInteractionText();

        Debug.Log("Test");
        // Show (or start showing) the photo in the UI, probably using an UI manager
        UIManager.instance.FadeToBlack();
        UIManager.instance.TeleportPlayer(targetLocation, this);

        base.Invoke();
    }

    public override void Cancel()
    {
        base.Cancel();
    }
}
