using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdowntimer : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField]
    public GameObject canvas2;
    [SerializeField]


    float timeLeft = 10.0f;
    [SerializeField]
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
            canvas2.SetActive(true);
        }
        }

    
}

