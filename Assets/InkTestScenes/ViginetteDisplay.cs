using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ViginetteDisplay : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Image viginette;
    [SerializeField] private Color targetColor = new Color(1, 1, 1, 0);
    [SerializeField] private float fadeSpeed;
    [SerializeField] private Color viginetteColor;
    private float curOpacity;

    public void Start()
    {

    }

    //Start revealing the Viginette [Public call when entering trigger]
    public void RevealViginette()
    {
        StopAllCoroutines();

        StartCoroutine(FadeViginetteIn());
    }

    IEnumerator FadeViginetteIn()
    {
        curOpacity += 0.2f;

        viginette.color = Color.Lerp(viginetteColor, targetColor, curOpacity);

        yield return new WaitForSeconds(0.125f);

        if(curOpacity < 1f) StartCoroutine(FadeViginetteIn());

        else
        {
            curOpacity = 1f;

            //Invoke("HideViginette", 2); //Testing, remove on final
        }
    }

    //Start hiding the viginette [Public call when leaving trigger]
    public void HideViginette()
    {
        StopAllCoroutines();

        StartCoroutine(FadeViginetteOut());
    }

    IEnumerator FadeViginetteOut()
    {
        curOpacity -= 0.2f;

        viginette.color = Color.Lerp(viginetteColor, targetColor, curOpacity);

        yield return new WaitForSeconds(0.125f);

        if (curOpacity > 0f) StartCoroutine(FadeViginetteOut());

        else
        {
            curOpacity = 0f;

            //Invoke("RevealViginette", 2); //Testing, remove on final
        }
    }

    //Alter the expected color [All alterations are on the scale of 0.0 - 1.0, not 0 - 255]
    public void ChangeColorTarget(Color newColor, float alpha)
    {
        targetColor = newColor;
        targetColor.a = alpha;
    }

}
