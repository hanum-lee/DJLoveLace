﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class PlayPause : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 clickPos;
    bool clicked;
    public GameObject object1;
    public Renderer rende;
    public Material matPlay;
    public Material matPause;

    public UnityEvent testing1B;
    public UnityEvent testing2T;

    public Animator cubeAnimator;
    bool playing;

    void Start()
    {
        matPlay = Resources.Load<Material>("Materials/CubeMatPlay");
        matPause = Resources.Load<Material>("Materials/CubeMatPause");
        playing = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        #if UNITY_ANDROID || UNITY_IOS
         clicked = Input.touchCount > 0;
         if(clicked)
             clickPos = Input.GetTouch(0).position;
        #else
        clicked = Input.GetMouseButtonDown(0);
        clickPos = Input.mousePosition;
        #endif
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        if (Physics.Raycast(ray, out hit) && clicked)
        {
            Debug.Log("Clicked on gameobject: " + hit.collider.name);

            

            if (playing)
            {
                //testing1B.Invoke();
                //cubeAnimator.SetBool("Playing", true);
                cubeAnimator.enabled = true;
                cubeAnimator.Play("Bouncing");
                playing = false;
                object1.GetComponent<MeshRenderer>().material = matPause;
                cubeAnimator.SetTrigger("isPlaying");
            }
            else
            {
                //testing2T.Invoke();
                //cubeAnimator.SetBool("Playing", false);
                cubeAnimator.enabled = false;
                playing = true;
                object1.GetComponent<MeshRenderer>().material = matPlay;
                cubeAnimator.ResetTrigger("isPlaying");
            }

            
            
        }

       
    }




}