using UnityEngine;

[CreateAssetMenu(fileName = "Ch_", menuName = "ChapterData/ChapterData", order = 1)]

public class ChapterData : ScriptableObject
{
    public int UID; // this is how the CODE talks about the chapters, so we can build them as chapter 10,20,30,40
                    // (in case we need to fit stuff in the middle!)
    public string displayName; // This is how the PLAYER will see the chapter, so we can say "Chapter 3: Whodunnit?"
                               //   instead of "30" as the chapter
    public ChapterData nextChapter;
}
