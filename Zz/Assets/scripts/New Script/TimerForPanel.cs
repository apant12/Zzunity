using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForPanel : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField]
    


    float timeLeft = 10.0f;
    // Start is called before the first frame update
    void Start()

    {


    }

    // Update is called once per frame

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            this.gameObject.SetActive(false);
            canvas.SetActive(true);
            
        }
    }

}
