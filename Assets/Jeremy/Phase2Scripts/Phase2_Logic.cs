using UnityEngine;

public class Phase2_Logic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject overlay;
    public GameObject curator;
    public GameObject timeline;
    public GameObject solve;

    public void CuratorOnScreen()
    {
        timeline.SetActive(false);
        curator.SetActive(true);
        solve.SetActive(false);
        overlay.SetActive(true);
    }

    public void TimelineOnScreen()
    {

        timeline.SetActive(true);
        curator.SetActive(false);
        solve.SetActive(false);
        overlay.SetActive(true);
    }

    public void SolveOnScreen()
    {
        timeline.SetActive(false);
        curator.SetActive(false);
        solve.SetActive(true);
        overlay.SetActive(true);

    }

    public void BackButton()
	{
        overlay.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test using escape to open menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Pressed");
            if (solve.activeSelf == false)
            {
                SolveOnScreen();
            }
        }
        if (solve.activeSelf == true)
        {
            //while this is open listen for it to be true.
        }
    }
}
