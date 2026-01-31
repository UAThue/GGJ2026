using UnityEngine;
using System.Collections.Generic;

/***************************
 * This is for showing people talking to the player. 
 * Right now, it's not really a "dialog" just a speech the character gives to the player, 
 *      but we can update that at polish time
 ***************************/

[CreateAssetMenu(fileName = "GA_", menuName = "GameActions/ShowDialogAction", order = 1)]
public class GA_ShowDialog : GameAction
{
    [Header("Visuals")]
    public Sprite overlay; // Any photo over the top of the dialog? If we put characters, they go here. Optional)  
    public Color fgColor; //Designated color of the foreground
    public Sprite background; // The background image of the dialog box. Have default, maybe?
    public Color bgColor; //Designated color of the background
    [TextArea] public string DialogText; // For now, dialogs are just one set of text.
    public Sprite speakerSprite; //Visual of who is speaking
    [Header("Sounds")]
    public List<AudioClip> invokeSounds;
    public List<AudioClip> cancelSounds;
    [Header("Music")]
    public AudioClip music;
    private AudioClip oldMusic;

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
        //TODO: Change the text on the dialog box
        //TODO: Change the background on the dialog box
        //TODO: Change the overlay image over the dialog window
        //TODO: Show (or start showing) the dialog window

        if (invokeSounds.Count > 0) {
            //TODO: Play all the sounds ( Sequentially? Parallel? I don't know! Need to solve this design! )
        }

        if (music != null) {
            //TODO: Save the current song (so we can go back)
            //TODO: play/Start blending into the new music
        }

        // Do the parent version -- which includes calling the UnityEvent-based additions
        base.Invoke();
    }

    public override void Cancel()
    {
        //TODO: Hide (or start hiding) the photo in the UI, probably via UI manager

        if (cancelSounds.Count > 0) 
        {
            //TODO: Play the sound(s) that happen when we cancel the action
        }

        if (music != null) {
            //TODO: play/start blending back to the old music (if we played new music)
        }

        // Do the parent version -- which includes calling the UnityEvent-based additions
        base.Cancel();
    }
}
