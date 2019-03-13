using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManag : MonoBehaviour
{

    

 
public void loadlevel(string level)
{
    SceneManager.LoadScene(level);

}
public void quitRequest()
    {
        Application.Quit();
    }


    //public void LoadNextLevel()
    //{
      //  Application.LoadLevel(Application.loadedLevel + 1);
    //}


}
