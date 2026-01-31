using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Singleton
    public ChapterData currentChapter; // What chapter are we currently in? 

    void Awake()
    {
        // TODO: Make singleton
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


}
