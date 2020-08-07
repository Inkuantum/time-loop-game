using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).gameObject != this.gameObject)
            {
                if (transform.parent.GetChild(i).gameObject.name.Equals(this.gameObject.name))
                {
                    Debug.Log("Found Laser");
                    Transform linkedLaser = transform.parent.GetChild(i);
                    Transform line = transform.GetChild(0);
                    LineRenderer lineRender = line.GetComponent<LineRenderer>();
                    lineRender.SetPosition(1, linkedLaser.localPosition);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
