using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button playButton;
    public Button replayButton;
    public GameObject titleScreen;
    public Image menuScreen;
    public SpriteRenderer cheeseSprite;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip eatingSound;
    public GetDistanceFromTarget getDistanceFromTarget;

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
        gameManagerAudio.volume = 0.75f;
        gameManagerAudio.Play();

        Cursor.visible = false;
        replayButton.gameObject.SetActive(false);
        titleScreen.SetActive(false);
        menuScreen.enabled = false;
        cheeseSprite.enabled = true;
        getDistanceFromTarget.enabled = true;

    }

    public void GameOver()
    {
        gameManagerAudio.PlayOneShot(eatingSound, 1.3f);
        Cursor.visible = true;
        replayButton.gameObject.SetActive(true);
        cheeseSprite.enabled = false;
        getDistanceFromTarget.enabled = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
