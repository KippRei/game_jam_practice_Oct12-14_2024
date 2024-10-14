using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestTimesScreen : MonoBehaviour
{
    [SerializeField]
    TMP_Text one, two, three, four, five, six;
    // Start is called before the first frame update
    void Start()
    {
        one.text += PlayerPrefs.GetFloat("level1highscore");
        two.text += PlayerPrefs.GetFloat("level11highscore");
        three.text += PlayerPrefs.GetFloat("level111highscore");
        four.text += PlayerPrefs.GetFloat("level1111highscore");
        five.text += PlayerPrefs.GetFloat("level11111highscore");
        six.text += PlayerPrefs.GetFloat("level111111highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("title", LoadSceneMode.Single);
        }
    }
}
