using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class GameAction : ScriptableObject
{
    [Header("Additional Actions")]
    public UnityEvent OnInvoke;
    public UnityEvent OnCancel;

    public virtual void Cancel()
    {
        // This function is overriden in child classes with whatever we want to do to hard code ENDING the action

        // After we do whatever is hardcoded in the child, we can also do the actions designers "staple on to the end"
        OnCancel.Invoke();
    }

    public virtual void Invoke()
    {
        // This function is overriden in child classes with whatever we want to hard code into this action

        // After we do whatever is hardcoded in the child, we can also do the actions designers "staple on to the end"
        OnInvoke.Invoke();
    }
}
