using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Sleep : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel1, _panel2, _panel3, _button;

    public Clock a;

    private void Start()
    {
        a = FindObjectOfType<Clock>();
    }

    public void OnClick()
    {
        var _button = EventSystem.current.currentSelectedGameObject;
        if (_button != null)
        {
            if (_button.name == "SleepButton")
            {
                a.DealAlertness("Sleep");
                a.DealTiredness("Sleep");
                StartCoroutine(WaitSleep());
            }
        }
    }

    IEnumerator WaitSleep()
    {
        _panel1.SetActive(false);
        _panel3.SetActive(false);
        _panel2.SetActive(true);

        yield return new WaitForSeconds(10f);
        _panel1.SetActive(true);
        _panel3.SetActive(true);
        _panel2.SetActive(false);
    }
}
