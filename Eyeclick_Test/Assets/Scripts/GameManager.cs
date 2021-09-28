using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject FinishLevelUI;
    void Update()
    {
        //restart level
        if (Input.GetKeyDown("r")) { 
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
     }
    }
    public void FinishLevel(){
        FinishLevelUI.SetActive(true);
    }
}
