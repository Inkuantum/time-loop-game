using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRewind : MonoBehaviour
{
    public List<GameObject> houses;

    public int activeHouse = 0;

    public GameObject rewindScreen;

    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHouseState();
        //rewindScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Time Rewind"))
        {
            activeHouse++;
            if (activeHouse >= houses.Count) activeHouse = 0;
            ChangeHouseState();
            rewindScreen.SetActive(true);
            StartCoroutine(DisableCanvas(2f * Time.deltaTime));
            if (pauseMenu.isPaused)
            {
                pauseMenu.ChangeBackgroundState();
            }
        }
    }

    public void ChangeHouseState()
    {
        //Loop through houses list
        for(int i = 0; i<houses.Count; i++)
        {
            GameObject currentHouse = houses[i];
            for (int j = 0; j<currentHouse.transform.childCount; j++)
            {
                if(activeHouse == i)
                {
                    currentHouse.transform.GetChild(j).gameObject.SetActive(true);
                }
                else
                {
                    currentHouse.transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator DisableCanvas(float time)
    {
        yield return new WaitForSeconds(time);

        rewindScreen.SetActive(false);
    }
}
