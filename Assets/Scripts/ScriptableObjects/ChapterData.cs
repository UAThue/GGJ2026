using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Ch_", menuName = "ChapterData/ChapterData", order = 1)]

public class ChapterData : ScriptableObject
{
    public string displayName; // This is how the PLAYER will see the chapter, so we can say "Chapter 3: Whodunnit?"
                               //   instead of "30" as the chapter
    public ChapterData nextChapter;
    public UnityEvent OnChapterStart; // HACK! THIS IS BAD! DON'T DO IN FUTURE!  ONLY ACCESS STATIC FUNCTIONS!
    public UnityEvent OnChapterEnd; // HACK! THIS IS BAD! DON'T DO IN FUTURE!  ONLY ACCESS STATIC FUNCTIONS!
}
