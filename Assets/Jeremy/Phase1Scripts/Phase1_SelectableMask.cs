using UnityEngine;
using UnityEngine.UI;

public class Phase1_SelectableMask : MonoBehaviour
{

    public Image mySelectableMask;
    public bool selected;
    public enum maskColors
	{
        red,
        orange,
        yellow,
        green,
        blue,
        indigo,
        violet,
        white,
        black
	}

    public maskColors myMaskColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selected == true)
		{
            mySelectableMask.color = Color.white;
		}
		else
		{
            mySelectableMask.color = new Color(1, 1, 1, 0.6f);
		}
    }

    public void ClickMe()
    {
        if (selected == false)
        {
            if (Phase1_MaskSelector._phase1MaskSelector.numSelected >= 4)
            {
                //do nothing
            }
            else
            {
                selected = true;
                Phase1_MaskSelector._phase1MaskSelector.numSelected += 1;
            }
        }
        else
        {
            Phase1_MaskSelector._phase1MaskSelector.numSelected -= 1;
            selected = false;
        }
    }
}
