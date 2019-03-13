using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckAnswer3 : MonoBehaviour
{
    public Button answer1, answer2;
    [SerializeField]
    private GameObject _nextPrompt1, _nextPrompt2, _animation1, _animation2, _animation3, _currPrompt;
    private string _name;
    public Clock a;
    // Start is called before the first frame update
    private void Start()
    {
        a = FindObjectOfType<Clock>();
    }

    public void OnButtonClick()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            _name = button.name;
            if (_name == "Play")
            {
                StartCoroutine(PartyAnswer());
                a.DealAlertness(_name);
                a.DealTiredness(_name);
                StartCoroutine(NextPrompt(_nextPrompt1, 21.5f));
            }
            else if (_name == "Study")
            {
                a.DealAlertness(_name);
                a.DealTiredness(_name);
                _animation3.SetActive(true);
                StartCoroutine(NextPrompt(_nextPrompt1, 10f));
            }
        }
    }

    IEnumerator PartyAnswer()
    {
        _animation3.SetActive(false);
        _animation1.SetActive(true);
        yield return new WaitForSecondsRealtime(6.5f);
        _animation1.SetActive(false);
        yield return new WaitForSeconds(5f);
        _animation2.SetActive(true);
        yield return new WaitForSeconds(10f);
        _animation2.SetActive(false);
        _animation3.SetActive(true);
    }

    IEnumerator PlayAnimation(GameObject anim, float time)
    {
        anim.SetActive(true);
        yield return new WaitForSeconds(time);
        anim.SetActive(false);
    }

    IEnumerator NextPrompt(GameObject nextPrompt, float timeNeeded)
    {
        _currPrompt.SetActive(false);
        yield return new WaitForSeconds(timeNeeded);
        nextPrompt.SetActive(true);
    }
}
