using UnityEngine;

public class DialogueProxy : MonoBehaviour
{
    //Connection
    [SerializeField] DialogueUI parentUI;

    //Proxy to parent
    public void CallTypewriter()
    {
        parentUI.StartTypewriter();
    }
}
