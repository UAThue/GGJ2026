using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LogBookControl : MonoBehaviour
{
    public GameObject PauseMenuUI;

    public GameObject nextPageButton;
    public GameObject prevPageButton;

    public List<string> information = new List<string>();

    bool bookOpen;

    public int pageNumber = 1;

    public TextMeshProUGUI logBookText;
    public TextMeshProUGUI pageNumberText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenBook();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Adds information in the logbook
    public void addInformation(string info)
    {
        information.Add(info);
    }

    //Will Switch over to the next padge
    public void NextPageButton()
    {
        //Goes to the next page in the log book
        if (pageNumber == 3)
        {
            Debug.Log("Unable to go past this number");
            return;
        }
        pageNumber++;
        OpenBook();
    }

    public void PreviousPageButton()
    {
        //Goes to the previous page in the log book
        if (pageNumber == 1)
        {
            Debug.Log("Unable to go past this number");
            return;
        }
        pageNumber--;
        OpenBook();
    }

    public void OpenBook()
    {
        //Prevent the player from acessing unavaiable pages
        if (pageNumber == 3)
        {
            nextPageButton.SetActive(false);
        }
        else
        {
            nextPageButton.SetActive(true);
        }
        if (pageNumber == 1)
        {
            prevPageButton.SetActive(false);
        }
        else
        {
            prevPageButton.SetActive(true);
        }


        //Resets the Logbook
        logBookText.text = "";
        pageNumberText.text = pageNumber.ToString();
        PauseMenuUI.SetActive(false);

        //Shows hints that the player obtained in the list from 1 - 6
        if (pageNumber == 1)
        {
            for(int i = 0; i < 6; i++)
            {
                if(i >= information.Count)
                {
                    Debug.Log("Not Enough Information to put in, returning");
                    return;
                }
                
                logBookText.text += information[i] + "\n" + "\n";
            }
        }

        //Shows hints that the player obtained in the list from 7 - 12
        else if (pageNumber == 2)
        {

            for (int i = 7; i < 12; i++)
            {
                if (i >= information.Count)
                {
                    Debug.Log("Not Enough Information to put in, returning");
                    return;
                }
                
                logBookText.text += information[i] + "\n" + "\n";
            }
        }

        //Opens Pause Menu
        else if (pageNumber == 3)
        {
              //Open Pause Menu
              PauseMenuUI.SetActive(true);
              
        }
    }
}
