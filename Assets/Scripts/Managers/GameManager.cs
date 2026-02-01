using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Singleton
    
    [Header("Important Objcts")] // NOTE: Keep this section as light as possible, please!
    public ControllerPlayer player;
    public ChapterData currentChapter; // What chapter are we currently in? 

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

    void InitializeGame()
    {
        //TODO: Start a new game session - clear any data, set everything to starting data. 
        //      This is also called when we need to "restart" a new game without closing, so remember to clear everything
    }

    public void LoadNextChapter()
    {
        // Set the chapter to the next chapters
        if (currentChapter.nextChapter != null) {
            currentChapter = currentChapter.nextChapter;
        } else {
            //TODO: Load Game Over ?
        }

        // TODO: Remove anyone who "left the puzzle" as we changed chapters.
        // Right now, we just leave them there, but they would be unable to be interacted with.

        // I don't think anything else really needs to be done 
        // Is there an intro to the level? Move back to the starting point?  Not sure!
    }
}
