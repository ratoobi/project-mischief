using UnityEngine;

public class MoveEyes : MonoBehaviour
{
    private readonly float xEyeOffset = -0.079f;
    private readonly float yEyeOffset = -0.704f;
    private readonly float xRatio = 0.0532f; // horizontal ratio between cheese and eyes position
    private readonly float yRatio = 0.0385f; // vertical ratio between cheese and eyes position

    public Transform cheeseBaitTransform;

    void Update()
    {
        transform.position = new Vector3((cheeseBaitTransform.position.x * xRatio) + xEyeOffset, (cheeseBaitTransform.position.y * yRatio) + yEyeOffset, transform.position.z);
    }
}
