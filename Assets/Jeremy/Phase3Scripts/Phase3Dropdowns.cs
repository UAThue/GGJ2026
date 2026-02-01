using UnityEngine;
using TMPro;

public class Phase3Dropdowns : MonoBehaviour
{
    public TMP_Dropdown da;
    public TMP_Dropdown d2;
    public TMP_Dropdown d3;
    public TMP_Dropdown d4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //1, 3, 4, 8
        int correct = 0;
        if(da.value == 1 || d2.value == 1 || d3.value == 1 || d4.value == 1)
		{
            correct += 1;
		}
        if (da.value == 3 || d2.value == 3 || d3.value == 3 || d4.value == 3)
        {
            correct += 1;
        }
        if (da.value == 4 || d2.value == 4 || d3.value == 4 || d4.value == 4)
        {
            correct += 1;
        }
        if (da.value == 8 || d2.value == 8 || d3.value == 8 || d4.value == 8)
        {
            correct += 1;
        }
        if(correct == 4)
		{
            Debug.Log("DID IT");
		}
    }
}
