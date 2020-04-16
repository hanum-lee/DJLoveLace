using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Yes, it's only three lines of code lol, but it still took me all afternoon to Google how to do it. 
// -Teale

public class Turning : MonoBehaviour
{
    float rate;
    float depth;

    AudioManager audioManager;
    public GameObject playCube;
    public PlayPause playPauseScript;

    void Awake()
    {
        rate = 0.8f;
        depth = 0.03f;
        audioManager = FindObjectOfType<AudioManager>();
        playCube = GameObject.Find("Cube");
        playPauseScript = playCube.GetComponent<PlayPause>();
    }


    void OnMouseDrag()
    {
        float rot = Input.GetAxis("Mouse Y"); //because the user is dragging up and down (Y)

        //transform.Rotate (x axis, y axis, z axis, what to rotating in relation to? Space.Self or Space.World)
        transform.Rotate(0.0f, -rot, 0.0f, Space.Self);
        // Even though the object is rotating around the x axis in the Unity editor, 
        // for some reason it's the y axis in this function (second parameter). I don't know why.
        if(rot < 0)
        {
            if(rate > 0)
            {
                rate -= 0.1f;
            }
            if(depth > 0)
            {
                depth -= 0.05f;
            }
            
        }
        else
        {
            if (rate < 20)
            {
                rate += 0.1f;
            }
            if (depth < 1)
            {
                depth += 0.05f;
            }
            
        }
        Debug.Log("Rate: " + rate);

	}

    void OnMouseUp()
    {
        audioManager.updateChrousFilter(rate,depth);
    }


}