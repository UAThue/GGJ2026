using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Vignette")]
    public Image vignette;
    public float vignetteFadeSpeed = 1; // How many units of alpha we chage in 1 second
    public float vignetteFadedInOpacity = 0.2f;
    public float vignetteFadedOutOpacity = 0.0f;

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
        // Set the vignette to the right color
        vignette.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
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
