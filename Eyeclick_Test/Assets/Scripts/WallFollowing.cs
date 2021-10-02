using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollowing : MonoBehaviour
{
     public bool isReady;
    public bool toRight;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        isReady = true;
        toRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!finish)
        {
            Solver();
        }
        
    }
    public void Solver()
    {
        if(isReady)
        {
        bool inFront = false;
        bool toRight = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.transform.forward, out hit, 1f))
        {            
            inFront = true;
        }
        if (Physics.Raycast(transform.position, this.transform.right, out hit, 1f))
        {            
            toRight = true;
        }
        if(inFront == false && toRight == false) 
        {
            if (toRight == false)
            {
                StartCoroutine(MoveForward());                
            }
            else
            {
                StartCoroutine(rotateRight());                
                toRight = false;
            }
        }
        else if(inFront == true && toRight) 
        {
            StartCoroutine(rotateLeft());
            
            toRight = false;
        }
        else if(inFront == true && !toRight) 
        {
            StartCoroutine(rotateRight());
           
            toRight = false;
        }
        else if (inFront == false && toRight == true) 
        {
            StartCoroutine(MoveForward());
            
            toRight = true;
        }
            isReady = false;
        }
    }
    public IEnumerator MoveForward()
    {
       
        for (int i = 0; i < 180; i++)
        {
            this.transform.position += (this.transform.forward / 180);
            yield return null;
        }
        SetReady();
    }

    public IEnumerator rotateLeft()
    {
        
        for (int i = 0; i < 180; i++)
        {
            this.transform.Rotate(new Vector3(0f, -0.5f, 0f));
            yield return null;
        }
        SetReady(); 
    }

    public IEnumerator rotateRight()
    {
        for (int i = 0; i < 180; i++)
        {
            this.transform.Rotate(new Vector3(0f, 0.5f, 0f));
            yield return null;
        }
        SetReady();
    }

    public void SetReady()
    {
        if (!isReady)
            isReady = true;
    }

   

    public void close()
    {
        finish = true;
    }
}
