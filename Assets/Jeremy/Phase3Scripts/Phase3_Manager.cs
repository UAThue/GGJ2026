using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Phase3_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject phase3UI;
    public static Phase3_Manager _phase3Manager;

    public GameObject[] maps;

	public void Awake()
	{
        if (_phase3Manager == null)
        {
            _phase3Manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	public void OpenUI()
    {
        phase3UI.SetActive(true);
    }

    public void CloseUI()
	{
        phase3UI.SetActive(false);
    }

    public void TimeButtons(int num)
	{
        foreach(GameObject g in maps)
		{
            g.SetActive(false);
		}
        maps[num].SetActive(true);           
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test using escape to open menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Pressed");
            if (phase3UI.activeSelf == false)
            {
                OpenUI();
            }
        }
    }
}
