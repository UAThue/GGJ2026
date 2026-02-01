using UnityEngine;
using System.Collections.Generic;

public class ControllerPlayer : Controller
{
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
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
