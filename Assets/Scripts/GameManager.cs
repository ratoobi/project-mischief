using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button playButton;
    public GameObject titleScreen;
    public Image menuScreen;
    public SpriteRenderer cheeseSprite;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip eatingSound;
    public MoveCheese moveCheese;

    AudioSource gameManagerAudio;

    void Start()
    {
        gameManagerAudio = GetComponent<AudioSource>();
        moveCheese = moveCheese.GetComponent<MoveCheese>();
    }

    public void StartGame()
    {
        gameManagerAudio.Stop();
        gameManagerAudio.loop = true;
        gameManagerAudio.clip = gameMusic;
        gameManagerAudio.volume = 1.0f;
        gameManagerAudio.Play();

        gameManagerAudio.Play();
        titleScreen.SetActive(false);
        menuScreen.enabled = false;
        cheeseSprite.enabled = true;
        Cursor.visible = false;

        moveCheese.isGameActive = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Eat()
    {
        gameManagerAudio.PlayOneShot(eatingSound, 1.0f);
    }
}
