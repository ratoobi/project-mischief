using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    public Text buttonText;

    Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    public void IncreaseButtonSize()
    {
        buttonAnimator.SetTrigger("increase_size_trig");
    }

    public void DecreaseButtonSize()
    {
        buttonAnimator.SetTrigger("decrease_size_trig");
    }
}
