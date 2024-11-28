using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Canvas inGame;
    public Canvas pauseMenu;
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        inGame.enabled = true;
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            time.timeScale = 0f;
            inGame.enabled = false;
            pauseMenu.enabled = true;
        }
        else
        {
            time.timeScale = 1f;
            inGame.enabled = false;
            pauseMenu.enabled = true;
        }
    }
}
4m 30 secs into the video ;)