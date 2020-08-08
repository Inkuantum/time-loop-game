using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    public int keys = 0;

    float horizontalMove = 0f;

    float verticalMove = 0f;

    bool jump = false;

    bool inDoor = false;

    bool inButton = false;

    Transform linkedDoor;

    Transform line;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        verticalMove = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Vertical") && verticalMove > 0)
        {
            if (inDoor == true)
            {
                if(linkedDoor != null)
                {
                    transform.position = linkedDoor.position;
                    verticalMove = 0;
                }
            }else if (inButton == true)
            {
                if(line != null)
                {
                    line.gameObject.SetActive(false);
                }
            }
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door"))
        {
            inDoor = true;
            Transform doorParent = collision.gameObject.transform.parent;
            if (doorParent.gameObject.tag.Equals("Locked"))
            {
                if(keys > 0)
                {
                    Transform newDoorParent = doorParent.parent;
                    GameObject.Destroy(doorParent.gameObject);
                    collision.gameObject.transform.parent = newDoorParent;
                    collision.gameObject.GetComponent<Collider2D>().enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < doorParent.childCount; i++)
                {
                    if (doorParent.GetChild(i).gameObject != collision.gameObject)
                    {
                        if (doorParent.GetChild(i).gameObject.name.Equals(collision.gameObject.name))
                        {
                            linkedDoor = doorParent.GetChild(i);
                        }
                    }
                }
            }
        }else if (collision.gameObject.tag.Equals("Key"))
        {
            keys++;
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag.Equals("Button"))
        {
            inButton = true;
            string number = collision.gameObject.name.Split('#')[1];
            Transform lasers = GameObject.Find("Future Spikes").transform;
            for(int i = 0; i < lasers.childCount; i++)
            {
                if(lasers.GetChild(i).name.Equals("Laser #" + number))
                {
                    if(lasers.GetChild(i).transform.childCount > 0)
                    {
                        line = lasers.GetChild(i).transform.GetChild(0);
                    }
                }
            }
        }
        else if (collision.gameObject.tag.Equals("Spikes"))
        {
            transform.position = new Vector3(0.37f, 0f, 0f);
        }
        else if (collision.gameObject.tag.Equals("Hostile"))
        {
            transform.position = new Vector3(0.37f, 0f, 0f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door"))
        {
            inDoor = false;
            linkedDoor = null;
        }else if (collision.gameObject.tag.Equals("Button"))
        {
            inButton = false;
            line = null;
        }
    }
}
