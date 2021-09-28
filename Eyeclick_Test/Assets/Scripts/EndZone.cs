using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndZone : MonoBehaviour
{
    public Text txtName;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider colli){
        gameManager.FinishLevel();
        txtName = GameObject.Find("Canvas/Name").GetComponent<Text>();
        if(colli.gameObject.tag=="Player"){
                txtName.text="player";
        }
        if(colli.gameObject.tag=="Comp"){
                txtName.text="computer";
        }
        
    }
}
