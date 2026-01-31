using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GA_", menuName = "GameActions/FadeVignette", order = 1)]
public class GA_FadeVignette : GameAction
{
    [Header("Vignette Data")]
    public Color targetColor = Color.white;

    [Header("Sounds")]
    public List<AudioClip> invokeSounds;
    public List<AudioClip> cancelSounds;

    // Private variables
    private float curOpacity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {        
    }

    public override void Invoke()
    {
        // Show the vignette -- in the new color, but save current opacity
        Color newColor = UIManager.instance.vignette.color;
        newColor.r = targetColor.r;
        newColor.g = targetColor.r;
        newColor.b = targetColor.r;
        UIManager.instance.vignette.color = newColor;


        UIManager.instance.ShowVignette();

        if (invokeSounds.Count > 0) {
            //TODO: Play all the sounds ( Sequentially? Parallel? I don't know! Need to solve this design! )
        }

        // Do the parent version -- which includes calling the UnityEvent-based additions
        base.Invoke();
    }

    public override void Cancel()
    {
        //Hide the vignette
        UIManager.instance.HideVignette();

        if (cancelSounds.Count > 0) 
        {
            //TODO: Play the sound(s) that happen when we cancel the action
        }

        // Do the parent version -- which includes calling the UnityEvent-based additions
        base.Cancel();
    }
}
