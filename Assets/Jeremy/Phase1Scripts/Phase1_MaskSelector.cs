using UnityEngine;

public class Phase1_MaskSelector : MonoBehaviour
{
    public GameObject phase1UI;
    public static Phase1_MaskSelector _phase1MaskSelector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Phase1_SelectableMask[] allMasks;
    public int numSelected = 0;

    private void Awake()
    {
        if (_phase1MaskSelector == null)
        {
            _phase1MaskSelector = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public void openUI()
    {
        phase1UI.SetActive(true);
    }

    public void closeUI()
	{
        phase1UI.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //Test using escape to open menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Pressed");
            if (phase1UI.activeSelf == false)
			{
                openUI();
			}
        }

       //Check for win
       int winCount = 0;
        foreach(Phase1_SelectableMask m in allMasks)
		{
            if(m.myMaskColor == Phase1_SelectableMask.maskColors.black)
			{
                if(m.selected == true)
				{
                    winCount += 1;
				}
			}else if(m.myMaskColor == Phase1_SelectableMask.maskColors.orange)
			{
                if (m.selected == true)
                {
                    winCount += 1;
                }
            }
            else if (m.myMaskColor == Phase1_SelectableMask.maskColors.green)
			{
                if (m.selected == true)
                {
                    winCount += 1;
                }
            }
            else if (m.myMaskColor == Phase1_SelectableMask.maskColors.violet)
			{
                if (m.selected == true)
                {
                    winCount += 1;
                }
            }
            if(winCount == 4)
			{
                //WIN
                Debug.Log("WIN");
			}

        }
}
}
