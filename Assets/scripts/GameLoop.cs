using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    player player;
    [SerializeField]
    GameObject pauseMenu, hitBtnToStart, key_to_next_level;
    [SerializeField]
    TMP_Text time_text;
    public bool is_paused = true;
    public bool game_started = false;
    private bool level_win = false;
    private string next_level;
    private float level_time = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        hitBtnToStart.SetActive(true);
        pauseMenu.SetActive(false);
        key_to_next_level.SetActive(false);
        next_level = SceneManager.GetActiveScene().name + '1';
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_paused)
        {
            level_time += Time.deltaTime;
        }

        if (Input.anyKeyDown && !game_started)
        {
            hitBtnToStart.SetActive(false);
            game_started = true;
            is_paused = false;
        }

        if (game_started)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                is_paused = !is_paused;
            }

            if (is_paused)
            {
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
            }

            if (player.how_many == 0)
            {
                is_paused = true;
                level_win = true;
                game_started = false;
                float best_time = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "highscore");
                if (level_time < best_time || best_time <= 0.5f)
                {
                    Debug.Log("new");
                    PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "highscore", level_time);
                    PlayerPrefs.Save();
                }
                time_text.text = "Time: " + level_time;
                key_to_next_level.SetActive(true);
            }
        }

        if (level_win)
        {
            if (Input.anyKeyDown)
            {
                if (next_level != "level1111111")
                {
                    player.how_many = 2;
                    SceneManager.LoadScene(next_level, LoadSceneMode.Single);
                }
                else
                {
                    player.how_many = 2;
                    SceneManager.LoadScene("win", LoadSceneMode.Single);
                }
            }
        }
    }
}
