using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChaser : MonoBehaviour
{
    public Transform ballsTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ballsTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, ballsTransform.position.y, transform.position.z);
        }
    }
}
