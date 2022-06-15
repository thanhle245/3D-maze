using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     Vector3 newPosition;
     Quaternion playerCube;
     public float speed=2f;
     public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
             if (Input.GetMouseButtonDown(0)) 
             {
                 SetPosition();
             }
             if(isMoving){
                Movement();
             }
            
         
    }
    void SetPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,1000)){
            newPosition =hit.point;
            isMoving = true;
        }
    }
    void Movement(){
        transform.position =Vector3.MoveTowards(transform.position,newPosition,speed* Time.deltaTime);
        if(transform.position == newPosition){
            isMoving= false;
        }
    }
}
