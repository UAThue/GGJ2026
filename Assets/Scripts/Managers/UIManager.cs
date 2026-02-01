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
    [Header("Solution Entry UIs")]
    public GameObject Chapter1SolutionObject;
    public GameObject Chapter2SolutionObject;
    public GameObject Chapter3SolutionObject;
    public GameObject Chapter4SolutionObject;

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

    public void ToggleChapter1SoltionUI()
    {
        if (Chapter1SolutionObject.activeInHierarchy) {
            HideChapter1SolutionUI();
        }
        else {
            ShowChapter1SolutionUI();
        }
    }

    public void ToggleChapter2SoltionUI()
    {
        if (Chapter2SolutionObject.activeInHierarchy) {
            HideChapter2SolutionUI();
        }
        else {
            ShowChapter2SolutionUI();
        }
    }

    public void ToggleChapter3SoltionUI()
    {
        if (Chapter3SolutionObject.activeInHierarchy) {
            HideChapter3SolutionUI();
        }
        else {
            ShowChapter3SolutionUI();
        }
    }

    public void ToggleChapter4SoltionUI()
    {
        if (Chapter4SolutionObject.activeInHierarchy) {
            HideChapter4SolutionUI();
        }
        else {
            ShowChapter4SolutionUI();
        }
    }

    public void ShowChapter1SolutionUI()
    {
        GameManager.HideHUD();
        GameManager.instance.SetPlayerMove(false);
        Chapter1SolutionObject.SetActive(true);
    }
    public void ShowChapter2SolutionUI()
    {
        GameManager.HideHUD();
        GameManager.instance.SetPlayerMove(false);
        Chapter2SolutionObject.SetActive(true);
    }
    public void ShowChapter3SolutionUI()
    {
        GameManager.HideHUD();
        GameManager.instance.SetPlayerMove(false);
        Chapter3SolutionObject.SetActive(true);
    }
    public void ShowChapter4SolutionUI()
    {
        GameManager.HideHUD();
        GameManager.instance.SetPlayerMove(false);
        Chapter4SolutionObject.SetActive(true);
    }

    public void HideChapter1SolutionUI()
    {
        GameManager.ShowHUD();
        GameManager.instance.SetPlayerMove(true);
        Chapter1SolutionObject.SetActive(false);
    }
    public void HideChapter2SolutionUI()
    {
        GameManager.ShowHUD();
        GameManager.instance.SetPlayerMove(true);
        Chapter2SolutionObject.SetActive(false);
    }
    public void HideChapter3SolutionUI()
    {
        GameManager.ShowHUD();
        GameManager.instance.SetPlayerMove(true);
        Chapter3SolutionObject.SetActive(false);
    }
    public void HideChapter4SolutionUI()
    {
        GameManager.ShowHUD();
        GameManager.instance.SetPlayerMove(true);
        Chapter4SolutionObject.SetActive(false);
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

        // Hide all solutions
        HideChapter1SolutionUI();
        HideChapter2SolutionUI();
        HideChapter3SolutionUI();
        HideChapter4SolutionUI();

        //Hide HUD
        HideHUD();

    }

    // Update is called once per frame
    void Update()
    {
        // THIS IS BAD. NEVER DO THIS - Update Chapter ever freaking frame
        chapterTitle.SetText(GameManager.instance.currentChapter.displayName);
    }

    public void ShowHUD()
    {
        HUDObject.SetActive(true);
    }

    public void HideHUD()
    {
        HUDObject.SetActive(false);
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
