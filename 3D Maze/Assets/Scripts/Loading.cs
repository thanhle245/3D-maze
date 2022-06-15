using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart(){
        SceneManager.LoadScene("Level");
    }
    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
