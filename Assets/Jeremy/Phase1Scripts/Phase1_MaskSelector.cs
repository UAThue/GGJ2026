using UnityEngine;

public class Phase1_MaskSelector : MonoBehaviour
{
    public GameObject phase1UI;
    public static Phase1_MaskSelector _phase1MaskSelector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Phase1_SelectableMask[] allMasks;
    public int numSelected = 0;
    private bool isLoading = false;

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
        // Freeze the player
        GameManager.instance.SetPlayerMove(false);
        phase1UI.SetActive(true);
    }

    public void closeUI()
	{
        // Freeze the player
        GameManager.instance.SetPlayerMove(true);
        phase1UI.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //Test using R to open menu
        if (Input.GetKeyDown(KeyCode.R)) {
            if (phase1UI.activeSelf == false) {
                openUI();
            }
            else {
                closeUI();
            }
        }

        //Check for win
        int winCount = 0;
        foreach (Phase1_SelectableMask m in allMasks) {
            if (m.myMaskColor == Phase1_SelectableMask.maskColors.black) {
                if (m.selected == true) {
                    winCount += 1;
                }
            }
            else if (m.myMaskColor == Phase1_SelectableMask.maskColors.orange) {
                if (m.selected == true) {
                    winCount += 1;
                }
            }
            else if (m.myMaskColor == Phase1_SelectableMask.maskColors.green) {
                if (m.selected == true) {
                    winCount += 1;
                }
            }
            else if (m.myMaskColor == Phase1_SelectableMask.maskColors.violet) {
                if (m.selected == true) {
                    winCount += 1;
                }
            }
            if (winCount == 4) {
                //WIN
                Debug.Log("WIN");

                // Next chapter in 1 second -- UGH. NEVER USE INVOKE!
                if (!isLoading) {
                    // Save that we are loading
                    isLoading = true;

                    // Stop Player Movement
                    GameManager.instance.SetPlayerMove(false);

                    // TODO: Play Stinger

                    // Delay and load
                    Invoke("LoadNext", 1.0f);
                }
            }

        }
    }

    public void LoadNext()
    {
        // Move player to root position


        GameManager.instance.LoadNextChapter();
        // Deactivate this object -- NOTE: I am assuming this is the parent object!!!!
        closeUI();

        // Set the game up to use the next UI


        GameManager.instance.SetPlayerMove(true);
    }

}
