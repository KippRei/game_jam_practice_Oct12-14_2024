using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SeekerPhantom : MonoBehaviour
{
    [SerializeField]
    GameLoop gameloop;
    [SerializeField]
    GameObject p1, p2;
    SpriteRenderer p1_renderer, p2_renderer;
    [SerializeField]
    Sprite human;
    [SerializeField]
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        p1_renderer = p1.GetComponent<SpriteRenderer>();
        p2_renderer = p2.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameloop.is_paused)
        {
            if (p1_renderer != null && p1_renderer.sprite == human)
            {
                float step = speed * Time.deltaTime;
                transform.position = MoveTowardsPlayer(transform.position, p1.transform.position, step);
            }
            else if (p2_renderer != null)
            {
                float step = speed * Time.deltaTime;
                transform.position = MoveTowardsPlayer(transform.position, p2.transform.position, step);
            }
        }
    }

    Vector3 MoveTowardsPlayer(Vector3 curr_pos, Vector3 player_pos, float speed)
    {
        float x = player_pos.x - curr_pos.x ;
        float y = player_pos.y - curr_pos.y;
        float angle = Mathf.Atan2(y, x);
        float x_dir = speed * Mathf.Cos(angle);
        float y_dir = speed * Mathf.Sin(angle);
        return new Vector3(curr_pos.x + x_dir, curr_pos.y + y_dir, curr_pos.z);
    }
}
