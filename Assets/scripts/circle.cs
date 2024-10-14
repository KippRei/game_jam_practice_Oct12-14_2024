using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour, ICustomMessageTarget
{
    private bool curr_color = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void beat()
    {
        if (curr_color)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            curr_color = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            curr_color = true;
        }
    }
}
