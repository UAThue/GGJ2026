using UnityEngine;
using System.Collections.Generic;

public class DTDTest : MonoBehaviour
{
    
    public DuctTapeDictionary<ChapterData, GameAction> dictionaryTest;
    [Header("Test Data")]
    public ChapterData keyTest;
    public List <GameAction> fillMeUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillMeUp = dictionaryTest.FindAll(keyTest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
