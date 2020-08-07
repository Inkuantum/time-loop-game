using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRender = this.gameObject.GetComponent<LineRenderer>();
        RaycastHit2D hit;

        if(Physics2D.Raycast(lineRender.GetPosition(0), lineRender.GetPosition(1)){

        }
    }
}
