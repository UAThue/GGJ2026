using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapterComplete : MonoBehaviour
{

    // This UI will wait for chapter to be complete. It will fade in, then destroy the previous UI.
    //It will then update the fourth UI to animate.
    //Then it will play an intro for the next chapter and load the UI for that chapter (except 4 which is always there)
    public Image blackScreenFade;
    public TMP_Text chapterCompleteText;
    public TMP_Text newChapterText;
    public TMP_Text[] summationList;

    [TextArea(15, 10)]
    public string[] pregame1;
    [TextArea(15, 10)]
    public string[] summationList1;
    [TextArea(15, 10)]
    public string[] summationList2;
    [TextArea(15, 10)]
    public string[] summationList3;


    private float lerper;

    public int currentChapter = 0;
    public ScreenStates currentScreenState;
    public enum ScreenStates
	{
        idle,
        theCaseBegins,
        fadeBlackIn,
        chapterCompleteText,
        summation1,
        summation2,
        summation3,
        summation4,
        switchToLogicGrid,
        fadeOutLogicGrid,
        newChapterText,
        loadBehind,
        fadeNewChapterTextAndBlackout
    }

    void Start()
    {
        currentScreenState = ScreenStates.theCaseBegins;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentScreenState)
        {
            case ScreenStates.idle:
                //Waiting
                break;
            case ScreenStates.fadeBlackIn:
                lerper += Time.deltaTime;
                blackScreenFade.color = Color.Lerp(Color.clear, Color.black, lerper);
                if (lerper >= 1)
                {
                    currentScreenState = ScreenStates.chapterCompleteText;
                    lerper = 0;
                }
                break;
            case ScreenStates.chapterCompleteText:
                lerper += Time.deltaTime;
                if (lerper > .3f)
                {
                    chapterCompleteText.gameObject.SetActive(true);
                }
                if (lerper > 1.2f)
                {
                    chapterCompleteText.gameObject.SetActive(false);
                }
                if (lerper > 1.5f)
                {
                    currentScreenState = ScreenStates.summation1;
                    lerper = 0;
                    // Set up summation
                    for (int i = 0; i < 4; i++)
                    {
                        if (currentChapter == 0)
                        {
                            summationList[i].text = pregame1[i];
                        }
                        else if (currentChapter == 1)
                        {
                            summationList[i].text = summationList1[i];
                        }
                        else if (currentChapter == 2)
                        {
                            summationList[i].text = summationList2[i];
                        }
                        else
                        {
                            summationList[i].text = summationList3[i];
                        }
                    }
                }
                break;
            case ScreenStates.summation1:
                lerper += Time.deltaTime;
                if (summationList[0].text != "")
                {
                    if (lerper > 0.3f)
                    {
                        summationList[0].gameObject.SetActive(true);
                    }
				}
				else
				{
                    //Skip.
                    lerper = 3f;
				}
                if (lerper > 3f)
                {
                    lerper = 0;
                    currentScreenState = ScreenStates.summation2;
                }
                break;
            case ScreenStates.summation2:
                lerper += Time.deltaTime;
                if (summationList[1].text != "")
                {
                    if (lerper > 0.3f)
                    {
                        summationList[1].gameObject.SetActive(true);
                    }
                }
                else
                {
                    //Skip.
                    lerper = 3f;
                }
                if (lerper > 3f)
                {
                    lerper = 0;
                    currentScreenState = ScreenStates.summation3;
                }
                break;
            case ScreenStates.summation3:
                lerper += Time.deltaTime;
                if (summationList[2].text != "")
                {
                    if (lerper > 0.3f)
                    {
                        summationList[2].gameObject.SetActive(true);
                    }
                }
                else
                {
                    //Skip.
                    lerper = 3f;
                }
                if (lerper > 3f)
                {
                    lerper = 0;
                    currentScreenState = ScreenStates.summation4;
                }
                break;
            case ScreenStates.summation4:
                lerper += Time.deltaTime;
                if (summationList[3].text != "")
                {
                    if (lerper > 0.3f)
                    {
                        summationList[3].gameObject.SetActive(true);
                    }
                }
                else
                {
                    //Skip.
                    lerper = 3f;
                }
                if (lerper > 4f)
                {
                    lerper = 0;
                    currentScreenState = ScreenStates.switchToLogicGrid;
                    for (int i = 0; i < 3; i++)
                    {
                        summationList[i].text = "";
                        summationList[i].gameObject.SetActive(false);
                    }
                }
                break;
            case ScreenStates.switchToLogicGrid:
                //Waiting
                Phase4Manager_Grid._phase4Grid.BringUpUI();
                Phase4Manager_Grid._phase4Grid.go = true;
                break;
            case ScreenStates.fadeOutLogicGrid:
                //Waiting
                if (Phase4Manager_Grid._phase4Grid.go == false)
                {
                    lerper += Time.deltaTime;
                }
                if(lerper>3)
                {
                    Phase4Manager_Grid._phase4Grid.CloseUI();
                    lerper = 0;
                    currentScreenState = ScreenStates.newChapterText;
                }
                break;
            case ScreenStates.newChapterText:
                lerper += Time.deltaTime;
                if (lerper > .3f)
                {
                    newChapterText.gameObject.SetActive(true);
                }
                if (lerper > 1.5f)
                {
                    currentScreenState = ScreenStates.loadBehind;
                    lerper = 0;
                }
                break;
            case ScreenStates.loadBehind:
                //Load the right thing.

                currentScreenState = ScreenStates.fadeNewChapterTextAndBlackout;
                break;
            case ScreenStates.fadeNewChapterTextAndBlackout:
                lerper += Time.deltaTime;
                blackScreenFade.color = Color.Lerp(Color.black, Color.clear, lerper);
                newChapterText.color = Color.Lerp(Color.black, Color.clear, lerper);
                if (lerper >= 1)
                {
                    currentScreenState = ScreenStates.idle;
                    newChapterText.gameObject.SetActive(false);
                    lerper = 0;
                }
                break;
        }
    }

    
}
