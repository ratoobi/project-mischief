using UnityEngine;

public class GetDistanceFromTarget : MonoBehaviour
{
    private float xDistance;
    private float yDistance;
    private float distance;
    private readonly float minDistance = 1.7f;
    private readonly float maxDistance = 11.0f;
    private readonly float cooldownTime = 1.5f;
    private readonly float glomAnimationTime = 0.350f;
    private float timeout = 0.850f;
    private bool isInCooldown;
    private bool isPlayingGlomAnimation;

    public SpriteRenderer sadFaceSprite;
    public SpriteRenderer closedMouthFaceSprite;
    public SpriteRenderer openMouthFaceSprite;
    public SpriteRenderer neutralFaceSprite;
    public SpriteRenderer eyesSprite;
    public SpriteRenderer strongBlushSprite;
    public SpriteRenderer blushSprite;
    public SpriteRenderer neutralMouthSprite;
    public SpriteRenderer semiOpenMouthSprite;

    public GameManager gameManager;

    Animator starAnimator;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        starAnimator = GameObject.Find("Star Animation").GetComponent<Animator>();
        gameManager = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        AdjustOpacity();

        timeout -= Time.deltaTime;

        xDistance = transform.position.x;
        yDistance = transform.position.y;

        if (xDistance > -0.6f && xDistance < 0.32f && yDistance > -2.67f && yDistance < -1.77f)
        {
            if (timeout < 0 && !isInCooldown)
            {
                if (isPlayingGlomAnimation)
                {
                    isPlayingGlomAnimation = false;
                    ShowClosedMouthFace();
                    gameManager.GameOver();
                }
                else
                {
                    timeout = glomAnimationTime;
                    ShowOpenMouthFace();
                    isPlayingGlomAnimation = true;
                }
            }
                
            if (isInCooldown)
            {
                if (timeout < 0.900f)
                    ShowSadFace();
                if (timeout < 0)
                {
                    ShowNeutralFace();
                    isInCooldown = false;
                    isPlayingGlomAnimation = false;
                    timeout = 0.850f;
                }
            }
        }
        else if (xDistance > -4.0f && xDistance < 4.0f && yDistance > -4.20f && yDistance < 1.25f)
        {
            if (!isPlayingGlomAnimation)
            {
                timeout = 0.850f;
                ShowNeutralFace();
                semiOpenMouthSprite.enabled = true;
            }
            else if (isPlayingGlomAnimation)
                WaitForCooldown();
        }
        else if (xDistance > -8.0f && xDistance < 8.0f && yDistance > -4.70f && yDistance < 4.7f)
        {
            if (!isPlayingGlomAnimation)
            {
                timeout = 0.850f;
                ShowNeutralFace();
                neutralMouthSprite.enabled = true;
            }
            else if (isPlayingGlomAnimation)
                WaitForCooldown();
        }
        else
        {
            if (!isPlayingGlomAnimation)
            {
                timeout = 0.850f;
                ShowSadFace();
            }
            else if (isPlayingGlomAnimation)
                WaitForCooldown();
        }
    }

    private void WaitForCooldown()
    {
        if (!isInCooldown)
        {
            if (timeout < 0)
            {
                ShowClosedMouthFace();
                starAnimator.SetTrigger("star_trig");
                isInCooldown = true;
                timeout += cooldownTime;
            }
        }
        else
        {
            if (timeout < 0.900f)
                ShowSadFace();
            if (timeout < 0)
            {
                isInCooldown = false;
                isPlayingGlomAnimation = false;
            }
        }
    }
    private void ShowOpenMouthFace()
    {
        HideFaceSprites();
        openMouthFaceSprite.enabled = true;
    }

    private void ShowClosedMouthFace()
    {
        HideFaceSprites();
        closedMouthFaceSprite.enabled = true;
    }

    private void ShowNeutralFace()
    {
        HideFaceSprites();
        neutralFaceSprite.enabled = true;
        blushSprite.enabled = true;
        eyesSprite.enabled = true;
    }

    private void ShowSadFace()
    {
        HideFaceSprites();
        strongBlushSprite.enabled = true;
        sadFaceSprite.enabled = true;
        eyesSprite.enabled = true;
    }

    private void HideFaceSprites()
    {
        neutralFaceSprite.enabled = false;
        openMouthFaceSprite.enabled = false;
        closedMouthFaceSprite.enabled = false;
        sadFaceSprite.enabled = false;
        semiOpenMouthSprite.enabled = false;
        neutralMouthSprite.enabled = false;
        eyesSprite.enabled = false;
        blushSprite.enabled = false;
        strongBlushSprite.enabled = false;
    }

    private void AdjustOpacity()
    {
        Color blushSpriteColor = blushSprite.color;
        float rangeInterval = Mathf.Abs(minDistance - maxDistance);
        distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDistance), 2) + Mathf.Pow(Mathf.Abs(yDistance), 2));

        blushSpriteColor.a = 1 - ((distance - minDistance) * (1 / rangeInterval));

        if (blushSpriteColor.a < 0.33f)
            blushSpriteColor.a = 0.33f;
        if (blushSpriteColor.a > 0.85f)
            blushSpriteColor.a = 0.85f;

        blushSprite.color = blushSpriteColor;
    }
}
