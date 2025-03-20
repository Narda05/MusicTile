using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource music;
    public AudioClip ClickAudio;
    public AudioClip ClickAudio2;
    public AudioClip ClickAudio3;
    public AudioClip ClickAudio4;
    private int barIndex = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = transform.GetComponentInParent<AudioSource>();
    }
    public void SetBarIndex(int index)
    {
        barIndex = index;
    }
   

    public void ClickAdudioOn(int audioId)
    {
        if (audioId == 1)
            music.PlayOneShot(ClickAudio);
        else if (audioId == 2)
            music.PlayOneShot(ClickAudio2);
        else if (audioId == 3)
            music.PlayOneShot(ClickAudio3);
        else if (audioId == 4)
            music.PlayOneShot(ClickAudio4);

        if (!GameManager.Instance.GameOver)
        {
            GameManager.Instance.IncScore(); // Aumentar puntuación
        }

        if (barIndex != TrackManager.Instance.GetCurrentBarIndex())
        {
            // Si la respuesta es incorrecta, termina el juego
            Debug.Log("Incorrect! Game Over.");
            GameManager.Instance.EndGame();
        }
        else
        {
            // Si es correcta, avanzamos a la siguiente barra
            Debug.Log("Correct!");
            TrackManager.Instance.AdvanceTrack();
        }

    }
}