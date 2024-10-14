using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class start_btn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject button;
    private TMP_Text text;
    private bool mouse_over = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse_over && Input.GetMouseButtonDown(0))
        {
            if (gameObject.name == "start_btn")
            {
                SceneManager.LoadScene("level1");   
            }
            if (gameObject.name == "best_times_btn")
            {
                SceneManager.LoadScene("best_times");
            }
            if (gameObject.name == "option_btn")
            {
                Application.Quit(0);
            }
            if (gameObject.name == "return_btn")
            {
                SceneManager.LoadScene("title");
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.white;
        mouse_over = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.red;
        mouse_over = false;
    }
}
