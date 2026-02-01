using UnityEngine;
using TMPro;

public class Phase2_TextController : MonoBehaviour
{

    public static Phase2_TextController _phase2TextController;
    public TMP_Text textField;
    public TMP_Text titleField;

    private void Awake()
    {
        if (_phase2TextController == null)
        {
            _phase2TextController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Hide();
    }

    public void Show(string whatToShow, string title)
	{
        textField.text = whatToShow;
        titleField.text = title;
        this.gameObject.SetActive(true);
	}

    public void Hide()
	{
        this.gameObject.SetActive(false);
        textField.text = "";
        titleField.text = "";
    }

}
