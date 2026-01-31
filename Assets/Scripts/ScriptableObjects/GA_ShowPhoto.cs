using UnityEngine;
using System.Collections.Generic;

public enum PhotoLocation { LeftSide, RightSide, Middle };

[CreateAssetMenu(fileName = "GA_", menuName = "GameActions/ShowPhotoAction", order = 1)]
public class GA_ShowPhoto : GameAction
{
    [Header("Visuals")]
    public Sprite photo;
    public PhotoLocation screenLocation;
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
        //TODO: Show (or start showing) the photo in the UI, probably using an UI manager
        //      Be sure to take location into account -- we may just pass photoLocation into the UI Manager
        //      Can solve that later

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
