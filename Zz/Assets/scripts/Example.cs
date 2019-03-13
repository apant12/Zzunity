using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


    // Start is called before the first frame update

    

    public class Example : MonoBehaviour, IPointerClickHandler
{
    
        private timer  timercopy;
         
    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
            
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Clicked!");
        timercopy.switchprompt2();
       // timercopy.timerecorderp2();
        
        
        //StartCoroutine(wait());

    }
    void handler() {
        

    }
        IEnumerator wait()
        {
            yield return new WaitForSeconds(20);
            
    }
    void Start() {
        timercopy = FindObjectOfType<timer>();


    }
    }

