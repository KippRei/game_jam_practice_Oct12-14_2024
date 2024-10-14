using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    enum OPTIONS
    {
        CONTINUE_BTN,
        QUIT_BTN
    }
    [SerializeField]
    TMP_Text continue_btn, quit_btn;
    [SerializeField]
    GameLoop gameloop;
    private OPTIONS selection = OPTIONS.CONTINUE_BTN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selection = OPTIONS.CONTINUE_BTN;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            selection = OPTIONS.QUIT_BTN;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selection == OPTIONS.CONTINUE_BTN)
            {
                gameloop.is_paused = false;
            }
            else
            {
                SceneManager.LoadScene("title", LoadSceneMode.Single);
            }
        }

        if (selection == OPTIONS.CONTINUE_BTN)
        {
            continue_btn.fontStyle = FontStyles.Underline;
            quit_btn.fontStyle = FontStyles.Normal;
        }
        else
        {
            continue_btn.fontStyle = FontStyles.Normal;
            quit_btn.fontStyle = FontStyles.Underline;
        }
    }
}
