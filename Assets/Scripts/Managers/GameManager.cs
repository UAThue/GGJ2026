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

    }

    // Update is called once per frame
    void Update()
    {
        
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

    void InitializeGame()
    {
        //TODO: Start a new game session - clear any data, set everything to starting data. 
        //      This is also called when we need to "restart" a new game without closing, so remember to clear everything
    }

    public void LoadNextChapter()
    {
        // Set the chapter to the next chapters
        if (currentChapter.nextChapter != null) {
            currentChapter.OnChapterEnd.Invoke();

            currentChapter = currentChapter.nextChapter;
            currentChapter.OnChapterStart.Invoke();
        }
        else {
            //TODO: Load Game Over ? Or is that  just another chapter?
        }

        

        // I don't think anything else really needs to be done 
        // Is there an intro to the level? Move back to the starting point?  Not sure!
    }



    public static void DestroyTheInnocents()
    {
        instance.parentObjectForInnocents.SetActive(false);
    }
}
