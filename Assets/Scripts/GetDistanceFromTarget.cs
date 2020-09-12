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
    private bool isPlayingLiftFaceAnimation;
    private bool iSlightlyFrustrated;

    public SpriteRenderer sadFaceSprite;
    public SpriteRenderer closedMouthFaceSprite;
    public SpriteRenderer neutralFaceSprite;
    public SpriteRenderer eyesSprite;
    public SpriteRenderer blushSprite;
    public SpriteRenderer neutralMouthSprite;
    public SpriteRenderer semiOpenMouthSprite;

    public GameManager gameManager;

    Animator starAnimator;
    Animator openMouthFaceAnimator;
    Animator sadFaceAnimator;

    void Start()
    {
        sadFaceSprite.enabled = false;
        Physics2D.queriesStartInColliders = false;
        
        gameManager = gameManager.GetComponent<GameManager>();
        starAnimator = GameObject.Find("Star Animation").GetComponent<Animator>();
        openMouthFaceAnimator = GameObject.Find("NYN open mouth face").GetComponent<Animator>();
        sadFaceAnimator = GameObject.Find("lift nyn face ").GetComponent<Animator>();
    }

    private void Update()
    {
        AdjustOpacity();

        timeout -= Time.deltaTime;

        xDistance = transform.position.x;
        yDistance = transform.position.y;

        if (xDistance > -0.6f && xDistance < 0.32f && yDistance > -2.67f && yDistance < -1.57f)
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
                {
                    ShowSadFace();
                }
                if (timeout < 0)
                {
                    sadFaceAnimator.SetTrigger("hide_sprite_trig");
                    isPlayingLiftFaceAnimation = false;
                    ShowNeutralFace();
                    isInCooldown = false;
                    isPlayingGlomAnimation = false;
                    ResetTimeout();
                }
            }
        }
        else if (xDistance > -3.5f && xDistance < 3.5f && yDistance > -4.20f && yDistance < 1.25f)
        {
            if (!isPlayingGlomAnimation)
            {
                ResetTimeout();
                ShowNeutralFace();
                semiOpenMouthSprite.enabled = true;
            }
            else
                WaitForCooldown();
        }
        else if (xDistance > -8.0f && xDistance < 8.0f && yDistance > -4.70f && yDistance < 4.7f)
        {
            if (!isPlayingGlomAnimation)
            {
                ResetTimeout();
                ShowNeutralFace();
                neutralMouthSprite.enabled = true;
            }
            else
                WaitForCooldown();
        }
        else
        {
            if (!isPlayingGlomAnimation)
            {
                ResetTimeout();
                iSlightlyFrustrated = true;
                ShowSadFace();
                isPlayingLiftFaceAnimation = false;
            }
            else
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
            {
                iSlightlyFrustrated = false;
                ShowSadFace();
            }
            if (timeout < 0)
            {
                sadFaceAnimator.SetTrigger("hide_sprite_trig");
                isPlayingLiftFaceAnimation = false;
                isInCooldown = false;
                isPlayingGlomAnimation = false;
            }
        }
    }

    private void ShowOpenMouthFace()
    {
        HideFaceSprites();
        openMouthFaceAnimator.SetTrigger("open_mouth_trig");
    }

    private void ShowClosedMouthFace()
    {
        openMouthFaceAnimator.SetTrigger("hide_sprite_trig");
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
        AdjustOpacity(1.00f);

        if (iSlightlyFrustrated)
        {
            AdjustOpacity(0.25f);
            sadFaceSprite.enabled = true;
        }
        else if (!isPlayingLiftFaceAnimation)
        {
            sadFaceAnimator.SetTrigger("lift_face_trig");
            isPlayingLiftFaceAnimation = true;
        }

        eyesSprite.enabled = true;
        blushSprite.enabled = true;
    }

    private void HideFaceSprites()
    {
        neutralFaceSprite.enabled = false;
        closedMouthFaceSprite.enabled = false;
        sadFaceSprite.enabled = false;
        semiOpenMouthSprite.enabled = false;
        neutralMouthSprite.enabled = false;
        eyesSprite.enabled = false;
        blushSprite.enabled = false;
    }

    private void AdjustOpacity(float blushOpacity)
    {
        Color blushSpriteColor = blushSprite.color;
        blushSpriteColor.a = blushOpacity;
        blushSprite.color = blushSpriteColor;
    }

    private void AdjustOpacity()
    {
        Color blushSpriteColor = blushSprite.color;
        float rangeInterval = Mathf.Abs(minDistance - maxDistance);
        distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDistance), 2) + Mathf.Pow(Mathf.Abs(yDistance), 2));

        blushSpriteColor.a = 1 - ((distance - minDistance) * (1 / rangeInterval));

        if (blushSpriteColor.a < 0.33f) blushSpriteColor.a = 0.33f;
        if (blushSpriteColor.a > 0.85f) blushSpriteColor.a = 0.85f;

        blushSprite.color = blushSpriteColor;
    }

    private void ResetTimeout()
    {
        timeout = 0.850f;
    }
}
