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

    public void IncreaseReplayButtonSize()
    {
        buttonAnimator.SetTrigger("increase_size_trig_2");
    }

    public void DecreaseReplayButtonSize()
    {
        buttonAnimator.SetTrigger("decrease_size_trig_2");
    }

    public void IncreasePlayButtonSize()
    {
        buttonAnimator.SetTrigger("increase_size_trig");
    }

    public void DecreasePlayButtonSize()
    {
        buttonAnimator.SetTrigger("decrease_size_trig");
    }
    public void IncreaseReturnButtonSize()
    {
        buttonAnimator.SetTrigger("increase_size_trig_3");
    }

    public void DecreaseReturnButtonSize()
    {
        buttonAnimator.SetTrigger("decrease_size_trig_3");
    }
}