using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [Header("UI Variables")]

    [SerializeField] Image background; //Color variation
    [SerializeField] Image foreground;

    [SerializeField] Image speakerImage; //Who is currently speaking
    [SerializeField] TMP_Text dialogueText; //What is being said

    [Header("Animator")]

    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    //Assign new attributes, Foreground opacity should always be 0.4f [Call this whenever displaying text]
    //Input of the ShowDialog Action
    public void AlterAttributes(GA_ShowDialog dialogObject)
    {
        //TODO: Remove control from the player

        //background.color = dialogObject.bgColor;
        //foreground.color = dialogObject.fgColor;

        speakerImage.sprite = dialogObject.speakerSprite;
        //dialogueText.text = currentAction.DialogText;
        //dialogueText.text = dialogObject.DialogText;

        dialogueText.maxVisibleCharacters = 0;
        AnimRise();
    }

    private void AnimRise()
    {
        anim.SetTrigger("EnterDialogue");
    }

    //[Call this to leave the interaction and return to the player controller]
    public void AnimFall() 
    {
        anim.SetTrigger("ExitDialogue");

        //TODO: Return control to the player
    }

    //Called from AnimRise() via animation event
    public void StartTypewriter()
    {
        StartCoroutine(Typewriter());
    }

    IEnumerator Typewriter()
    {
        dialogueText.maxVisibleCharacters++;

        yield return new WaitForSeconds(0.05f);

        if (dialogueText.maxVisibleCharacters != dialogueText.text.Length)
        {
            StartCoroutine(Typewriter());
        }
    }
}
