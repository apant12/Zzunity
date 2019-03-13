using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckAnswerSpec : MonoBehaviour
{
    public Button answer1, answer2;
    [SerializeField]
    private GameObject _nextPrompt1, _nextPrompt2, _animation1, _animation2, _animation3, _animation4, _currPrompt;
    private string _name;
    public Clock a;
    [SerializeField]
    private GameObject field;
    private bool isPaused = false;
    
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
            if (_name == "Study")
            {
                if (_animation4.active == true)
                {
                    a.DealAlertness(_name);
                    a.DealTiredness(_name);

                    StartCoroutine(NextPrompt(_nextPrompt1, 10f));
                }
                else
                {
                    StartCoroutine(StudyAnswer());
                    a.DealAlertness(_name);
                    a.DealTiredness(_name);

                    StartCoroutine(NextPrompt(_nextPrompt1, 16f));
                }
                
                
            }
            else if (_name == "Don't study")
            {
                if (_animation4.active == true)
                {
                    a.DealAlertness(_name);
                    a.DealTiredness(_name);

                    StartCoroutine(NextPrompt(_nextPrompt2, 10f));
                }
                else
                {
                    StartCoroutine(PlayAnimation(_animation3, 10f));
                    a.DealAlertness(_name);
                    a.DealTiredness(_name);

                    StartCoroutine(NextPrompt(_nextPrompt2, 10f));
                }
            }
        }
    }

    IEnumerator StudyAnswer()
    {
        //yield return new WaitForSeconds(20f);
        
        while (isPaused == true)
        {
            
            yield return null;
        }
        
            _animation3.SetActive(true);
            yield return new WaitForSecondsRealtime(6f);
            _animation3.SetActive(false);
            _animation2.SetActive(false);
            _animation1.SetActive(true);
            yield return new WaitForSeconds(10f);
            _animation1.SetActive(false);
            _animation2.SetActive(true);
            _animation4.SetActive(true);
        
            
        //yield return _sync();
    }

    IEnumerator PlayAnimation(GameObject anim, float time)
    {
        while (isPaused == true)
        {
            Debug.Log(isPaused);
            yield return null;
        }
        anim.SetActive(true);
        yield return new WaitForSeconds(time);
        anim.SetActive(false);
        _animation4.SetActive(true);
        //yield return _sync();
    }

    IEnumerator NextPrompt(GameObject nextPrompt, float timeNeeded)
    {
        while (isPaused == true)
        {
            Debug.Log(isPaused);
            yield return null;
        }
        _currPrompt.SetActive(false);
        yield return new WaitForSeconds(timeNeeded);
        nextPrompt.SetActive(true);
        //yield return _sync();
    }

    public Coroutine _sync()
    {
        return StartCoroutine(PauseRoutine());
    }

    public IEnumerator PauseRoutine()
    {
        while (isPaused)
        {
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForEndOfFrame();
    }
}
