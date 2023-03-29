using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompMovement : MonoBehaviour
{
    Rigidbody rb;
    private float seekSpeed =0.5f;
    public GameObject target;
    private int range=50;
    private bool isDetected=false;
    private RaycastHit hit;
    private float rotateSpeed =50f;
    // Start is called before the first frame update
    void Start()
    {
        // rb =GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if(!isDetected){
            Vector3 pos = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
        transform.Translate(Vector3.forward * seekSpeed *Time.deltaTime);
        Transform leftRaycast = transform;
        Transform rightRaycast = transform;
        if (Physics.Raycast(leftRaycast.position + (transform.right * 7), transform.forward, out hit, range) || 
            Physics.Raycast(rightRaycast.position - (transform.right * 7), transform.forward, out hit, range)) {
            if (hit.collider.gameObject.CompareTag("Wall")) {
                isDetected = true;
                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
        if (Physics.Raycast(transform.position - (transform.forward * 4), transform.right, out hit, 10) ||
            Physics.Raycast(transform.position - (transform.forward * 4), -transform.right, out hit, 10)) {
            if (hit.collider.gameObject.CompareTag("Wall")) {
                isDetected = false;
    }
  }
    }
    Debug.DrawRay(transform.position + (transform.right * 7), transform.forward * 20, Color.red);
  Debug.DrawRay(transform.position - (transform.right * 7), transform.forward * 20, Color.red);
  Debug.DrawRay(transform.position - (transform.forward * 4), -transform.right * 20, Color.yellow);
  Debug.DrawRay(transform.position - (transform.forward * 4), transform.right * 20, Color.yellow);
}

}
/// <summary>
/// AI try to avoid wall.
/// AI can detect target 
/// 
/// </summary>