using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = false;
    private bool canPlayLoopingVideo = true;
    private float splashScreenDelayTimeout = 0.5f;

    public bool isDebugging;

    public Button startGameButton;
    public Button quitButton;
    public Button returnButton;
    public Button replayButton;
    public GameObject titleScreen;
    public SpriteRenderer cheeseSprite;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip eatingSound;
    public GetDistanceFromTarget getDistanceFromTarget;
    public GameObject preloopVideoCanvas;
    public GameObject loopingVideoCanvas;
    public GameObject preloopVideo;
    public GameObject loopingVideo;
    public UnityEngine.Video.VideoPlayer preloopVideoPlayer;
    public UnityEngine.Video.VideoPlayer loopingVideoPlayer;
    public GameObject blackScreen;


    AudioSource gameManagerAudio;

    void Start()
    {
        Cursor.visible = false;

        gameManagerAudio = GetComponent<AudioSource>();

        loopingVideoPlayer = loopingVideo.GetComponent<UnityEngine.Video.VideoPlayer>();
        preloopVideoPlayer = preloopVideo.GetComponent<UnityEngine.Video.VideoPlayer>();

        if (isDebugging)
            StartGame();
        else
            preloopVideoPlayer.Play();
    }

    private void Update()
    {

        if (!isGameActive)
        {
            splashScreenDelayTimeout -= Time.deltaTime;

            if (splashScreenDelayTimeout < 0)
                blackScreen.SetActive(false);

            if (!preloopVideoPlayer.isPlaying && splashScreenDelayTimeout < 0 && canPlayLoopingVideo)
            {
                Cursor.visible = true;

                gameManagerAudio.clip = menuMusic;
                gameManagerAudio.Play();
                //preloopVideoCanvas.SetActive(false);
                loopingVideoCanvas.SetActive(true);
                loopingVideoPlayer.Play();
                startGameButton.gameObject.SetActive(true);
                quitButton.gameObject.SetActive(true);
                canPlayLoopingVideo = false;
            }
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        Cursor.visible = false;
        loopingVideoPlayer.Stop();
        titleScreen.SetActive(false);
        replayButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        cheeseSprite.enabled = true;
        getDistanceFromTarget.enabled = true;
    }

    public void GameOver()
    {
        gameManagerAudio.Stop();
        gameManagerAudio.PlayOneShot(eatingSound, 1.3f);
        Cursor.visible = true;
        replayButton.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        cheeseSprite.enabled = false;
        getDistanceFromTarget.enabled = false;
    }

    public void ReturnToTitleScreen()
    {
        returnButton.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);
        titleScreen.SetActive(true);
        loopingVideoPlayer.Play();
    }

    public void PlayGameMusic()
    {
        gameManagerAudio.Stop();
        gameManagerAudio.loop = true;
        gameManagerAudio.clip = gameMusic;
        gameManagerAudio.volume = 0.75f;
        gameManagerAudio.Play();
    }

    public void PlayMenuMusic()
    {
        gameManagerAudio.Stop();
        gameManagerAudio.loop = true;
        gameManagerAudio.clip = menuMusic;
        gameManagerAudio.volume = 1.0f;
        gameManagerAudio.Play();
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
