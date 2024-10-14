using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public interface ICustomMessageTarget : IEventSystemHandler
{
    // functions that can be called via the messaging system
    void beat();
}
public class timing : MonoBehaviour
{
    private double curr_time, next_beat, bpm;
    AudioSource audio_source;
    [SerializeField]
    AudioSource music;
    [SerializeField]
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        curr_time = music.time;
        bpm = 60f / 128f;
        next_beat = curr_time + bpm;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curr_time = music.time;
        if (curr_time >= next_beat)
        {
            next_beat += bpm;
            audio_source.PlayOneShot(audio_source.clip);
            ExecuteEvents.Execute<ICustomMessageTarget>(target, null, (x, y) => x.beat());
            Debug.Log(curr_time);
        }
    }
}
