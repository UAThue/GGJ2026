using UnityEngine;
using TMPro;

public class Phase2_HoverButton : MonoBehaviour
{

    public string hoverTitle;
    [TextArea(15, 20)]
    public string hoverText;

    public void assignToManager()
	{
        Phase2_TextController._phase2TextController.Show(hoverText, hoverTitle);
	}
}
