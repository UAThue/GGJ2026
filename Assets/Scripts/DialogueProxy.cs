using UnityEngine;

public class DialogueProxy : MonoBehaviour
{
    //Proxy to parent
    public void CallTypewriter()
    {
        UIManager.instance.StartTypewriter();
    }
}
