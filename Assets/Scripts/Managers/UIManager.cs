using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Vignette")]
    public GameObject vignetteObject;
    public Image vignette;
    public float vignetteFadeSpeed = 1; // How many units of alpha we chage in 1 second
    public float vignetteFadedInOpacity = 0.2f;
    public float vignetteFadedOutOpacity = 0.0f;
    [Header("Interaction Text")]
    public GameObject interactionObject;
    public Image interactionObjectBackground;
    public TMP_Text interactionObjectNameText;
    public TMP_Text interactionObjectPressEText;
    [Header("Dialog Box")]
    public GameObject dialogBoxObject;
    public Image dialogBoxBackground;
    public Image dialogBoxOverlay;
    public TMP_Text dialogueBoxText; //What is being said
    public Image dialogBoxSpeaker;
    public float typewriterDelay = 0.01f;
    [Header("Photo Popup")]
    public GameObject photoObject;
    public Image photo;
    [Header("In Game HUD")]
    public GameObject HUDObject;
    public Image logo;
    public TMP_Text chapterTitle;


    void Awake()
    {
        // Make Singleton
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the vignette to the right color, and hide it
        Color newColor = Color.white;
        newColor.a = 0;
        vignette.color = newColor;

        // Hide the interaction text
        HideInteractionText();

        // Hide photos
        HidePhoto();

        // Hide dialog box
        HideDialogBox();

        //TODO: Hide HUD
        
    }

    // Update is called once per frame
    void Update()
    {
        // THIS IS BAD. NEVER DO THIS - Update Chapter ever freaking frame
        chapterTitle.SetText(GameManager.instance.currentChapter.displayName);
    }

    public void ShowDialogBox ( Sprite background, Sprite foreground, string richText, Sprite speakerSprite )
    {
        Debug.Log("Showing Dialog");

        // Show the box
        dialogBoxObject.SetActive(true);

        // Set the background and foreground images
        dialogBoxBackground.sprite = background;
        dialogBoxOverlay.sprite = foreground;

        // Set the dialog text
        dialogueBoxText.SetText(richText);

        // Set the text to 0 so we can typewriter
        //dialogueBoxText.maxVisibleCharacters = 0;

        // If speaker sprite is null, turn off the box
            dialogBoxSpeaker.sprite = speakerSprite;

        // Start the typewriter!
        //StartTypewriter();
    }

    public void HideDialogBox()
    {
        // Hide the box
        dialogBoxObject.SetActive(false);
    }

    public void StartTypewriter()
    {
        StartCoroutine(Typewriter());
    }

    IEnumerator Typewriter()
    {
        // Add one to the text 
        dialogueBoxText.maxVisibleCharacters++;

        yield return new WaitForSeconds(typewriterDelay);

        if (dialogueBoxText.maxVisibleCharacters < dialogueBoxText.text.Length) {
            StartCoroutine(Typewriter());
        }
    }

    public void ShowInteractionText(string name = "", string interactionText = "<i>Press E to Interact</i>")
    {
        // Activate the UI element
        interactionObject.SetActive(true);

        // Set data
        interactionObjectNameText.SetText(name);
        interactionObjectPressEText.SetText(interactionText);
}

    public void HideInteractionText()
    {
        // Hide the UI element - Set text to nothing
        interactionObject.SetActive(false);
        interactionObjectNameText.SetText("");
        interactionObjectPressEText.SetText("");
    }

    public void ShowPhoto(Sprite photoToShow)
    {
        // Activate the UI element
        photoObject.SetActive(true);

        // Set data
        photo.sprite = photoToShow;
    }

    public void HidePhoto()
    {
        // Hide the UI element - Set text to nothing
        photoObject.SetActive(false);
    }

    public void ShowVignette()
    {
        StopAllCoroutines();
        StartCoroutine(FadeViginetteIn());
    }

    public void HideVignette()
    {
        StopAllCoroutines();
        StartCoroutine(FadeViginetteOut());
    }

    public IEnumerator FadeViginetteIn()
    {
        bool isFading = true;
        // Forever (or until we stop the coroutine)
        while (isFading) {

            // Find a value from our current a towards our target a, without moving more than our speed
            float newOpacity = Mathf.MoveTowards(vignette.color.a, vignetteFadedInOpacity, vignetteFadeSpeed * Time.deltaTime);
            Color tempColor = vignette.color;
            tempColor.a = newOpacity;
            vignette.color = tempColor;
            // If we are at the target, stop
            if (newOpacity == vignetteFadedInOpacity) {
                isFading = false;
            }

            // wait a frame and do this again!
            yield return null;
        }
        yield return null;
    }

    public IEnumerator FadeViginetteOut()
    {
        bool isFading = true;
        // Forever (or until we stop the coroutine)
        while (isFading) {

            // Find a value from our current a towards our target a, without moving more than our speed
            float newOpacity = Mathf.MoveTowards(vignette.color.a, vignetteFadedOutOpacity, vignetteFadeSpeed * Time.deltaTime);
            Color tempColor = vignette.color;
            tempColor.a = newOpacity;
            vignette.color = tempColor;

            // If we are at the target, stop
            if (newOpacity == vignetteFadedOutOpacity) {
                isFading = false;
            }

            // wait a frame and do this again!
            yield return null;
        }
    }
}
