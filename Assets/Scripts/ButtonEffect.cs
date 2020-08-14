using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    public Text buttonText;

    public void IncreaseFontSize()
    {
        buttonText.fontSize = 210;
    }

    public void DecreaseFontSize()
    {
        buttonText.fontSize = 190;
    }
}
