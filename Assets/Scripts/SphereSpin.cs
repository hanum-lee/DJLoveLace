using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpin : MonoBehaviour
{
    Transform thisObj;
    float rotationspeed = 100.0f;
    float dragspeed = 10.0f;

    float highestDragSpeed = 0;
    bool dragging = false;
    AudioManager audioManager;
    public GameObject playCube;
    public PlayPause playPauseScript;
    // Start is called before the first frame update
    void Start()
    {
        thisObj = this.transform;
        audioManager = FindObjectOfType<AudioManager>();
        playCube = GameObject.Find("Cube");
        playPauseScript = playCube.GetComponent<PlayPause>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragging)
        {
            thisObj.Rotate(0, Time.deltaTime * rotationspeed, 0, Space.World);
        }
    }

    void OnMouseDrag()
    {
        dragging = true;
        float rot = Input.GetAxis("Mouse X");

        transform.Rotate(0.0f, -rot * dragspeed, 0.0f, Space.World);

        if (-rot > highestDragSpeed)
        {     //Keep track of the fastest speed at which the user dragged
            highestDragSpeed = -rot;
        }


    }
    void OnMouseUp()
    {
        if (highestDragSpeed < 0.5)
        {         //Will equal 0 if user dragged in opposite direction
            highestDragSpeed = 0.5f;         //Make it very slow but still fast enough to see the spin
        }

        Debug.Log("highestDragSpeed: " + highestDragSpeed);

        dragging = false;
        rotationspeed = highestDragSpeed * 100;

        if (0.5 <= highestDragSpeed && highestDragSpeed <= 0.65)
        {
            Debug.Log("Drag Speed Category: SLOW");

            //DANIEL -> play the LOW-tempo audio file (with pitch depending on the last rope interaction)
            audioManager.tempo_indice = 2;
            playPauseScript.currentani = 2;
            audioManager.updateSound();
            

        }

        if (0.65 < highestDragSpeed && highestDragSpeed <= 1.5)
        {
            Debug.Log("Drag Speed Category: MEDIUM");
            //DANIEL -> play the NORMAL-tempo audio file (with pitch depending on the last rope interaction)
            audioManager.tempo_indice = 1;
            playPauseScript.currentani = 1;
            audioManager.updateSound();
        }

        if (1.5 < highestDragSpeed)
        {
            Debug.Log("Drag Speed Category: FAST");
            //DANIEL -> play the HIGH-tempo audio file (with pitch depending on the last rope interaction)
            audioManager.tempo_indice = 0;
            playPauseScript.currentani = 0;
            audioManager.updateSound();
        }


        highestDragSpeed = 0;   //Reset
    }
}
