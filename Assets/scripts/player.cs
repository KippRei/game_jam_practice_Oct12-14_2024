using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public static int how_many = 2;
    AudioSource audio_source;
    Collider2D player_col;
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField]
    float move_speed = 1.5f;
    [SerializeField]
    float player_speed = 0f;
    [SerializeField]
    Sprite human, ghost;
    [SerializeField]
    GameLoop gameloop;

    private HashSet<KeyCode> keys_down = new HashSet<KeyCode>();
    [SerializeField]
    private int number_of_keys_down = 0;

    // Start is called before the first frame update
    void Start()
    {
        keys_down.Add(KeyCode.A);
        keys_down.Add(KeyCode.S);
        keys_down.Add(KeyCode.D);
        keys_down.Add(KeyCode.W);
        player_col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audio_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var key in keys_down)
        {
            if (Input.GetKeyDown(key))
            {
                number_of_keys_down++;
            }
            if (Input.GetKeyUp(key))
            {
                number_of_keys_down--;
            }
        }

        if (!gameloop.is_paused && gameloop.game_started)
        {
            if (number_of_keys_down > 1)
            {
                player_speed = Mathf.Sin(Mathf.Sqrt(2) / 2) * move_speed * 1.1f * Time.deltaTime;
            }
            else
            {
                player_speed = move_speed * Time.deltaTime;
            }

            if (how_many < 2 && sr.sprite == ghost)
            {
                sr.sprite = human;
            }
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + player_speed, gameObject.transform.position.z);
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + player_speed, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - player_speed, gameObject.transform.position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - player_speed, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.Space) && how_many == 2)
            {
                audio_source.PlayOneShot(audio_source.clip);
                if (sr.sprite == human)
                {
                    sr.sprite = ghost;
                }
                else
                {
                    sr.sprite = human;
                }
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "phantom" && sr.sprite == human)
        {
            how_many = 2;
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }
        if (collision.gameObject.tag == "exit" && sr.sprite == human)
        {
            Destroy(gameObject);
            how_many--;
        }
    }
}
