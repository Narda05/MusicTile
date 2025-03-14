using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource music;
    public AudioClip ClickAudio;
    public AudioClip ClickAudio2;
    public AudioClip ClickAudio3;
    public AudioClip ClickAudio4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = transform.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickAdudioOn(int audioId)
    {
        if(audioId == 1)
            music.PlayOneShot(ClickAudio);
        else if (audioId == 2)
            music.PlayOneShot(ClickAudio2);
        else if (audioId == 3)
            music.PlayOneShot(ClickAudio3);
        else if (audioId == 4)
            music.PlayOneShot(ClickAudio4);

        TrackManager.Instance.AdvanceTrack();

    }
}
