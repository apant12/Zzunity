using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Clock : MonoBehaviour
{
    private Text _clockText;
    private float totalTime;
    private float _total;

    [SerializeField]
    private GameObject[] _clockFace;

    private int _time1;
    private int _time2;
    [SerializeField]
    private GameObject[] _prompt;
    [SerializeField]
    private GameObject[] _morningPrompt;
    [SerializeField]
    private GameObject[] _afternoonPrompt;
    [SerializeField]
    private GameObject[] _nightPrompt;
    [SerializeField]
    private GameObject[] _bedPrompt;
    [SerializeField]
    private GameObject[] _statusPrefab;
    private string _name;
    public Dictionary<string, Dictionary<string, int>> answers = new Dictionary<string, Dictionary<string, int>>();
    public float _maxTiredness = 10f;
    public float _currTiredness;
    public float _maxAlertness = 10f;
    public float _currAlertness;
    public Slider _tiredness;
    public Slider _alertness;
    [SerializeField]
    private GameObject _canvas1;
    [SerializeField]
    private GameObject _canvas2;
    private float _timeLeft = 10.0f;
    [SerializeField]
    private GameObject first;
    // int counter;
    //int minutes;
    // Start is called before the first frame update
    private int minutes;
    void Start()
    {
        _clockText = GetComponent<Text>();
        minutes = System.DateTime.Now.Hour;
        // totalTime = 0f;
        _currTiredness = 0;
        _currAlertness = _maxAlertness;
        _tiredness.value = CalculateTiredness();
        _alertness.value = CalculateAlertness();
        SetUpDictionary(1, 1, "Class");
        //SetUpDictionary(1, 0, "Bed");
        SetUpDictionary(0, 0, "Relax");
        SetUpDictionary(1, 2, "Coffee");
        SetUpDictionary(0, 1, "Breakfast");
        SetUpDictionary(1, -2, "Study");
        SetUpDictionary(3, -3, "Party");
        SetUpDictionary(0, 0, "Don't study");
        SetUpDictionary(-10, 10, "Sleep");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStatus();
        // int sysHour = 
        UpdateTimer(totalTime);
        totalTime += Time.deltaTime / 2;
        
    }

    void UpdateTimer(float seconds)
    {
        int sec = Mathf.RoundToInt(seconds % 60f);
        string formatedSeconds = seconds.ToString();

        if (sec == 60)
        {
            sec = 0;
            minutes += 1;
            totalTime = 0f;
        }

        _clockText.text = minutes.ToString("00") + ":" + sec.ToString("00");
        _time1 = minutes;
        _time2 = sec;
        switch (_time2)
        {
            case 0:
                _clockFace[4].SetActive(false);
                _clockFace[0].SetActive(true);
                break;
            case 10:
                _clockFace[0].SetActive(false);
                _clockFace[1].SetActive(true);
                break;
            case 20:
                _clockFace[1].SetActive(false);
                _clockFace[2].SetActive(true);
                break;
            case 30:
                _clockFace[2].SetActive(false);
                _clockFace[3].SetActive(true);
                break;
            case 40:
                _clockFace[3].SetActive(false);
                _clockFace[4].SetActive(true);
                break;
            case 50:
                _clockFace[4].SetActive(false);
                _clockFace[0].SetActive(true);
                break;
        }
    }
    

    void SetUpDictionary(int tirednessValue, int alertnessValue, string choice)
    {
        Dictionary<string, int> _value = new Dictionary<string, int>();
        _value.Add("Alertness", alertnessValue);
        _value.Add("Tiredness", tirednessValue);
        answers.Add(choice, _value);
    }

    public void DealAlertness(string name)
    {
        foreach (KeyValuePair<string, Dictionary<string, int>> i in answers)
        {
            if (i.Key == name)
            {
                foreach (KeyValuePair<string, int> j in i.Value)
                {
                    if (j.Key == "Alertness")
                    {
                        _currAlertness += j.Value;
                        _alertness.value = CalculateAlertness();
                    }
                }
            }
        }
    }

    public float CalculateTiredness()
    {

        return _currTiredness / _maxTiredness;
    }

    public float CalculateAlertness()
    {
        return _currAlertness / _maxAlertness;
    }

    public void DealTiredness(string name)
    {
        foreach (KeyValuePair<string, Dictionary<string, int>> i in answers)
        {
            if (i.Key == name)
            {
                foreach (KeyValuePair<string, int> j in i.Value)
                {
                    if (j.Key == "Tiredness")
                    {
                        _currTiredness += j.Value;
                        _tiredness.value = CalculateTiredness();
                    }
                }
            }
        }
    }

    private void ChangeStatus()
    {
        if (_currTiredness <= 10 && _currTiredness >= 8)
        {
            _statusPrefab[3].SetActive(false);
            _statusPrefab[4].SetActive(true);
        }
        else if (_currTiredness < 8 && _currTiredness >= 6)
        {
            _statusPrefab[2].SetActive(false);
            _statusPrefab[3].SetActive(true);
        }
        else if (_currTiredness < 6 && _currTiredness >= 4)
        {
            _statusPrefab[1].SetActive(false);
            _statusPrefab[2].SetActive(true);
        }
        else if (_currTiredness < 4 && _currTiredness >= 2)
        {
            _statusPrefab[0].SetActive(false);
            _statusPrefab[1].SetActive(true);
        }
        else if ( _currTiredness < 2 && _currTiredness >= 0)
        {
            _statusPrefab[4].SetActive(false);
            _statusPrefab[0].SetActive(true);
        }
    }

    private void ChangePanel(GameObject c1, GameObject c2, float time) 
    {
        c1.SetActive(false);
        c2.SetActive(true);
        time -= Time.deltaTime;
        Debug.Log(time);
        if (time < 0)
        {
            c1.SetActive(true);
            c2.SetActive(false);
        } 
    }

    IEnumerator SpawnFirst()
    {
        yield return new WaitForSeconds(5f);
        first.SetActive(true);
    }
}
