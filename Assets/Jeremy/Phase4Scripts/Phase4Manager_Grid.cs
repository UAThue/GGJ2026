using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Phase4Manager_Grid : MonoBehaviour
{
    public GameObject gridUI;
    public ChapterData finalChapter;

    public Sprite circle;
    public Sprite ex;
    public Sprite empty;
    public GridSpot[] entireGrid;
    public static Phase4Manager_Grid _phase4Grid;

    public TMP_Text[] names;
    public TMP_Text[] jobs;
    public TMP_Text[] colors;

    public GameObject closeButton;

    public bool go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum currentState
	{
       found1,
       found2,
       found3,
       readyToSolve
	};

    public currentState myCurrentState;
    private float lerpTimer;

    void Awake()
	{
        if (_phase4Grid == null)
        {
            _phase4Grid = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        foreach(TMP_Text t in names)
		{
            t.color = new Color(1, 1, 1, 0);
		}
        foreach (TMP_Text t in jobs)
        {
            t.color = new Color(1, 1, 1, 0);
        }
        foreach (TMP_Text t in colors)
        {
            t.color = new Color(1, 1, 1, 0);
        }
    }

    public void BringUpUI()
	{
        //In the future make this nice
        gridUI.SetActive(true);
	}

    public void CloseUI()
	{
        gridUI.SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if(GameManager.instance.currentChapter!= finalChapter)
		{
            closeButton.gameObject.SetActive(false);
		}
		else
		{
            closeButton.gameObject.SetActive(true);
        }*/
        if (go == true)
		{
            switch(myCurrentState)
			{
                case currentState.found1:
                    lerpTimer += Time.deltaTime;
                    foreach (TMP_Text t in colors)
                    {
                        Color lerpStart = new Color(1, 1, 1, 0);
                        Color lerpTarget = new Color(1, 1, 1, 1);
                        t.color = Color.Lerp(lerpStart, lerpTarget, lerpTimer);                       
                    }
                    if (lerpTimer >= 1)
                    {
                        lerpTimer = 0;
                        myCurrentState = currentState.found2;
                        go = false;
                    }
                    break;
                case currentState.found2:
                    lerpTimer += Time.deltaTime;
                    foreach (TMP_Text t in jobs)
                    {
                        Color lerpStart = new Color(1, 1, 1, 0);
                        Color lerpTarget = new Color(1, 1, 1, 1);
                        t.color = Color.Lerp(lerpStart, lerpTarget, lerpTimer);
                    }
                    if (lerpTimer >= 1)
                    {
                        lerpTimer = 0;
                        go = false;
                        myCurrentState = currentState.found3;
                    }
                    break;
                case currentState.found3:
                    lerpTimer += Time.deltaTime;
                    foreach (TMP_Text t in names)
                    {
                        Color lerpStart = new Color(1, 1, 1, 0);
                        Color lerpTarget = new Color(1, 1, 1, 1);
                        t.color = Color.Lerp(lerpStart, lerpTarget, lerpTimer);
                    }
                    if (lerpTimer >= 1)
                    {
                        lerpTimer = 0;
                        go = false;
                        myCurrentState = currentState.readyToSolve;
                    }
                    break;
                case currentState.readyToSolve:
                    //Solve time.
                    break;
            }
		}
        //Check for victory
        bool victory = true;
        foreach(GridSpot g in entireGrid)
		{
            if(g.state != g.requiredState)
			{
                victory = false;
			}
		}
        if(victory == true)
		{
            Debug.Log("WIN THE GAME");
		}
    }
}
