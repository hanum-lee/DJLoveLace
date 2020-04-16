using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRope : MonoBehaviour
{
    // Start is called before the first frame update

    private float mouseY;
    bool initalrelease;
    float initialspeed;
    Rigidbody rb;
    float testing = .5f;

    Transform[] childrenObject = new Transform[4];
    List<Transform> childrenTrans;
    List<GameObject> childGameObject;
    AudioManager audioManager;
    GameObject playCube;
    PlayPause playPauseScript;



    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
        playCube = GameObject.Find("Cube");
        playPauseScript = playCube.GetComponent<PlayPause>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initalrelease)
        {
            var modspeed = initialspeed;
            Debug.Log("Speed: " + modspeed);
            initalrelease = false;
        }
        
    }

    void OnMouseDrag()
    {
        mouseY = Input.GetAxis("Mouse Y");
        
        //transform.position = new Vector3(rb.position.x, Input.mousePosition.y, rb.position.z);
        //transform.Translate(transform.position.x, mouseY, transform.position.z, Space.World);
        rb.AddForce(mouseY * testing * Vector3.up );
        playPauseScript.Pause();

    }

    void OnMouseUp()
    {
        Debug.Log(mouseY);
        var velocity = rb.velocity;
        Debug.Log("Velocity:" + velocity);
        initialspeed = velocity.magnitude;
        if(mouseY > 0)
        {
            Debug.Log("Pitch UP");
            playPauseScript.Pause();
            audioManager.increasePitch();
            audioManager.updateSound();
            
        }
        else
        {
            Debug.Log("Pitch DOWN");
            playPauseScript.Pause();
            audioManager.decreasePitch();
            audioManager.updateSound();
            
        }
        initalrelease = true;
    }
}
