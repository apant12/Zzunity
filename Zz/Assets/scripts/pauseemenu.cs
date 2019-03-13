using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseemenu : MonoBehaviour {

    public GameObject panelp;
    [SerializeField]

    
    
   public void sctivepausemenu () {
        
        panelp.SetActive(true);
        Time.timeScale = 0;
        
    }
	
	// Update is called once per frame
	public void resume () {
      Time.timeScale = 1;
      panelp.SetActive(false);
    }
}
