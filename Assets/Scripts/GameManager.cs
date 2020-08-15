using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button playButton;
    public GameObject titleScreen;
    public Image menuScreen;
    public SpriteRenderer cheeseSprite;
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    AudioSource gameManagerAudio;

    void Start()
    {
        gameManagerAudio = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        gameManagerAudio.Stop();
        gameManagerAudio.loop = true;
        gameManagerAudio.clip = gameMusic;
        gameManagerAudio.volume = 0.6f;
        gameManagerAudio.Play();

        gameManagerAudio.Play();
        titleScreen.SetActive(false);
        menuScreen.enabled = false;
        cheeseSprite.enabled = true;
        Cursor.visible = false;
    }
}
