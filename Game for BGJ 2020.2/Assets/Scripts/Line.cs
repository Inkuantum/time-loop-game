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
        Transform linkedLaser = transform.parent.GetComponent<Laser>().linkedLaser;
        LineRenderer lineRender = this.gameObject.GetComponent<LineRenderer>();
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, linkedLaser.position);
        

        if (hitInfo){
            if (hitInfo.transform.tag.Equals("Player"))
            {

                hitInfo.transform.position = new Vector3(0.37f, 0f, 0f);
            }
        }
    }
}
