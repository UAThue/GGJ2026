using UnityEngine;

[CreateAssetMenu(fileName = "Ch_", menuName = "ChapterData/ChapterData", order = 1)]

public class ChapterData : ScriptableObject
{
    public string displayName; // This is how the PLAYER will see the chapter, so we can say "Chapter 3: Whodunnit?"
                               //   instead of "30" as the chapter
    public ChapterData nextChapter;
}
