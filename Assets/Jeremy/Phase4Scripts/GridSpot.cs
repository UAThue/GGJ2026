using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridSpot : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int state;
    //0 is off, 1 is x, 2 is O
    public int requiredState = 1;

    public Image myImage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedMe()
	{
        if(state == 0)
		{
            state = 1;
            myImage.sprite = Phase4Manager_Grid._phase4Grid.ex;
		}else if(state==1)
		{
            state = 2;
            myImage.sprite = Phase4Manager_Grid._phase4Grid.circle;
        }
        else
		{
            state = 0;
            myImage.sprite = Phase4Manager_Grid._phase4Grid.empty;
        }
    }
}
