using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private bool canPlayLoopingVideo = false;

    public Button playButton;
    public Button replayButton;
    public Button quitButton;
    public GameObject titleScreen;
    public Image menuScreen;
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

    AudioSource gameManagerAudio;

    void Start()
    {
        gameManagerAudio = GetComponent<AudioSource>();

        //loopingVideoPlayer = loopingVideo.GetComponent<UnityEngine.Video.VideoPlayer>();
        //preloopVideoPlayer = preloopVideo.GetComponent<UnityEngine.Video.VideoPlayer>();

        //preloopVideoPlayer.Play();

    }

    //private void Update()
    //{
    //    splashScreenDelayTimeout -= Time.deltaTime;

    //    if (!preloopVideoPlayer.isPlaying && splashScreenDelayTimeout < 0 && !loopingVideoPlayer.isPlaying)
    //    {

    //        //loopingVideoCanvas.SetActive(true);
    //        canPlayLoopingVideo = true;
    //    }

    //    if (canPlayLoopingVideo)
    //    {
    //        //gameManagerAudio.clip = menuMusic;
    //        gameManagerAudio.Play();
    //        //preloopVideoCanvas.SetActive(false);
    //        loopingVideoCanvas.SetActive(true);
    //        loopingVideoPlayer.Play();
    //        canPlayLoopingVideo = false;
    //    }

    //}
    public void StartGame()
    {
        Cursor.visible = false;
        titleScreen.SetActive(false);
        menuScreen.enabled = false;
        cheeseSprite.enabled = true;
        getDistanceFromTarget.enabled = true;

    }

    public void GameOver()
    {
        gameManagerAudio.Stop();
        gameManagerAudio.PlayOneShot(eatingSound, 1.3f);
        Cursor.visible = true;
        replayButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        cheeseSprite.enabled = false;
        getDistanceFromTarget.enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    //public void ReturnToTitleScreen()
    //{
    //    returnButton.gameObject.SetActive(false);
    //    titleScreen.SetActive(true);
    //    menuScreen.enabled = true;
    //    cheeseSprite.enabled = false;
    //    getDistanceFromTarget.enabled = false;
    //}
}
