using UnityEngine;

public class GetDistanceFromTarget : MonoBehaviour
{
    private float xDistance;
    private float yDistance;
    private readonly float minDistance = 1.7f;
    private readonly float maxDistance = 11.0f;
    private float distance;

    public SpriteRenderer closedMouthSprite;
    public SpriteRenderer openMouthSprite;
    public SpriteRenderer blushSprite;

    MoveCheese moveCheese;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        moveCheese = GetComponent<MoveCheese>();
    }

    private void FixedUpdate()
    {
        AdjustOpacity();

        if (moveCheese.isGameActive)
        {
            xDistance = transform.position.x;
            yDistance = transform.position.y;

            if (xDistance > -4.5f && xDistance < 4.5f && yDistance > -2.75f && yDistance < 2.75f)
            {
                closedMouthSprite.enabled = false;
                openMouthSprite.enabled = true;
            }

            else if (xDistance > -8.5f && xDistance < 8.5f && yDistance > -5.0f && yDistance < 5.0f)
            {
                closedMouthSprite.enabled = true;
                openMouthSprite.enabled = false;
            }
        }
    }

    private void AdjustOpacity()
    {
        Color blushSpriteColor = blushSprite.color;
        float rangeInterval = Mathf.Abs(minDistance - maxDistance);
        distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDistance), 2) + Mathf.Pow(Mathf.Abs(yDistance), 2));

        blushSpriteColor.a = 1 - ((distance - minDistance) * (1 / rangeInterval));

        if (blushSpriteColor.a < 0.33f)
            blushSpriteColor.a = 0.33f;

        blushSprite.color = blushSpriteColor;
    }
}
