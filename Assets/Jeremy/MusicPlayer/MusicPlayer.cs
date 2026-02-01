using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer _music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip[] songs;
    public AudioSource musicPlayer;
    public float chosenVolume = 0.8f;

    public int currentSong = 0;
    private float volumeLerp;

    public songStates currentState;
    public enum songStates
	{
        playing,
        fadeOutOldSong,
        switchSongs,
        fadeInNewSong
	}

    public void Awake()
    {
        if (_music == null)
        {
            _music = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	public void Start()
	{
        musicPlayer.volume = 0;
        musicPlayer.clip = songs[0];
        musicPlayer.Play();
        currentState = songStates.fadeInNewSong;
	}

	public void Update()
	{
		switch(currentState)
		{
            case songStates.playing:

                break;
            case songStates.fadeOutOldSong:
                volumeLerp -= Time.deltaTime;
                musicPlayer.volume = Mathf.Lerp(0, chosenVolume, volumeLerp);
                if (volumeLerp <=0)
                {
                    currentState = songStates.switchSongs;
                }
                break;
            case songStates.switchSongs:
                //Just cycle
                currentSong += 1;
                if(currentSong == songs.Length)
				{
                    currentSong = 0;
				}
                musicPlayer.Stop();
                musicPlayer.clip = songs[currentSong];
                musicPlayer.Play();
                currentState = songStates.fadeInNewSong;
                break;
            case songStates.fadeInNewSong:
                volumeLerp += Time.deltaTime/2;
                musicPlayer.volume = Mathf.Lerp(0, chosenVolume, volumeLerp);
                if(volumeLerp>= 1)
				{
                    currentState = songStates.playing;
				}
                break;
        }
	}

    public void NextSong()
	{
        currentState = songStates.fadeOutOldSong;
	}

}
