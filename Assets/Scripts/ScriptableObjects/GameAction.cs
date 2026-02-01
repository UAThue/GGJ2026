using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class GameAction : ScriptableObject
{
    [Header("Additional Actions")]
    public UnityEvent OnInvoke;
    public UnityEvent OnCancel;
    [Header("Is This Currently Invoked/Running?")]
    public bool isActive = false;

    public virtual void Cancel()
    {
        // This function is overriden in child classes with whatever we want to do to hard code ENDING the action

        // Save that we are no longer running
        isActive = false;

        // After we do whatever is hardcoded in the child, we can also do the actions designers "staple on to the end"
        OnCancel.Invoke();
    }

    public virtual void Invoke()
    {
        // This function is overriden in child classes with whatever we want to hard code into this action

        // Save that we are running
        isActive = true;

        // After we do whatever is hardcoded in the child, we can also do the actions designers "staple on to the end"
        OnInvoke.Invoke();
    }

    public void OnDestroy()
    {
        // Always return to false when done
        isActive = false;
    }
}
