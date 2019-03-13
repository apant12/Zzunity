using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedButtonClicked : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField]
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.active == true)
        {
            isPaused = true;
        }
    }
}
