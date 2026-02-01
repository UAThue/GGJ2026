using UnityEngine;
using TMPro;

public class Phase2_Dropdowns : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Dropdown d1a;
    public TMP_Dropdown d1b;

    public TMP_Dropdown d2a;
    public TMP_Dropdown d2b;

    public TMP_Dropdown d3a;
    public TMP_Dropdown d3b;

    public TMP_Dropdown d4a;
    public TMP_Dropdown d4b;



    // Update is called once per frame
    void Update()
    {
        int correct = 0;
        //Hack. The number pairs are 0 8, 1 1, 4 5, 8 2
        if(d1a.value == 0 || d2a.value == 0 || d3a.value == 0 || d4a.value == 0)
		{
            if (d1a.value == 0 && d1b.value == 8)
            {
                correct += 1;
            }
            else if (d2a.value == 0 && d2b.value == 8)
            {
                correct += 1;
            }
            else if (d3a.value == 0 && d3b.value == 8)
            {
                correct += 1;
            }
            else if (d4a.value == 0 && d4b.value == 8)
            {
                correct += 1;
            }
        }
        //Test 2
        if (d1a.value == 1 || d2a.value == 1 || d3a.value == 1 || d4a.value == 1)
        {
            if (d1a.value == 1 && d1b.value == 1)
            {
                correct += 1;
            }
            else if (d2a.value == 1 && d2b.value == 1)
            {
                correct += 1;
            }
            else if (d3a.value == 1 && d3b.value == 1)
            {
                correct += 1;
            }
            else if (d4a.value == 1 && d4b.value == 1)
            {
                correct += 1;
            }
        }
        //Test 3
        if (d1a.value == 4 || d2a.value == 4 || d3a.value == 4 || d4a.value == 4)
        {
            if (d1a.value == 4 && d1b.value == 5)
            {
                correct += 1;
            }
            else if (d2a.value == 4 && d2b.value == 5)
            {
                correct += 1;
            }
            else if (d3a.value == 4 && d3b.value == 5)
            {
                correct += 1;
            }
            else if (d4a.value == 4 && d4b.value == 5)
            {
                correct += 1;
            }
        }
        //Test 4
        if (d1a.value == 8 || d2a.value == 8 || d3a.value == 8 || d4a.value == 8)
        {
            if (d1a.value == 8 && d1b.value == 2)
            {
                correct += 1;
            }
            else if (d2a.value == 8 && d2b.value == 2)
            {
                correct += 1;
            }
            else if (d3a.value == 8 && d3b.value == 2)
            {
                correct += 1;
            }
            else if (d4a.value == 8 && d4b.value == 2)
            {
                correct += 1;
            }
        }
        if (correct == 4)
		{
            //Finished
            Debug.Log("got it");
		}
    }
}
