using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Singleton
    
    [Header("Important Objcts")] // NOTE: Keep this section as light as possible, please!
    public ControllerPlayer player;
    public ChapterData currentChapter; // What chapter are we currently in? 
    [Header("Objects for Cheap Jam Hacks")]
    public GameObject parentObjectForInnocents;
    public bool canPlayerMove = true;
    public Vector3 playerStartLocation;


    [Header("Game Data")]
    public ChapterData startingChapter;

    void Awake()
    {
        // Make Singleton
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager.instance.ShowMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayerToStart()
    {
        player.gameObject.transform.position = playerStartLocation;
    }

    public void SetPlayerMove(bool canMove)
    {
        canPlayerMove = canMove;

        if (canMove) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public static void ShowHUD()
    {
        UIManager.instance.ShowHUD();
    }

    public static void HideHUD()
    {
        UIManager.instance.HideHUD();
    }

    public static void ToggleHUD()
    {
        if (UIManager.instance.HUDObject.activeInHierarchy) {
            HideHUD();
        } else {
            ShowHUD();
        }
    }

    public void ToggleSolveScreen()
    { 
        switch (currentChapter.ID) {
            case 0:
                break;
            case 1:
                UIManager.instance.ToggleChapter1SoltionUI();
                break;
            case 2:
                UIManager.instance.ToggleChapter2SoltionUI();
                break;
            case 3:
                UIManager.instance.ToggleChapter3SoltionUI();
                break;
            case 4:
                UIManager.instance.ToggleChapter4SoltionUI();
                break;
        }
    }

    public void InitializeGame()
    {
        //TODO: Start a new game session - clear any data, set everything to starting data. 
        //      This is also called when we need to "restart" a new game without closing, so remember to clear everything

        // ACK! For now, just hide the menu and start playing!
        Debug.Log("init game");
        UIManager.instance.HideMenu();
    }

    public void LoadNextChapter()
    {
        // Set the chapter to the next chapters
        if (currentChapter.nextChapter != null) {
            currentChapter.OnChapterEnd.Invoke();

            // Move to next song
            MusicPlayer._music.NextSong();

            // Hide ALL the solution screens
            UIManager.instance.HideChapter1SolutionUI();
            UIManager.instance.HideChapter2SolutionUI();
            UIManager.instance.HideChapter3SolutionUI();
            UIManager.instance.HideChapter4SolutionUI();

            // Move to next level and run OnStart
            currentChapter = currentChapter.nextChapter;
            currentChapter.OnChapterStart.Invoke();
        }
        else {
            //TODO: Load Game Over ? Or is that  just another chapter?
        }

        MovePlayerToStart();
        // I don't think anything else really needs to be done 


        // Is there an intro to the level? Move back to the starting point?  Not sure!
    }



    public static void DestroyTheInnocents()
    {
        instance.parentObjectForInnocents.SetActive(false);
    }
}
