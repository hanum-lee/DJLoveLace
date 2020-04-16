using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;



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
    public bool playing;

    public AudioSource sound;
    public AudioClip audioclip;

    string[] tempoAnimation = new string[] { "Bouncing_IncreasedTempo", "Bouncing","Bouncing_DecreasedTempo" };

    public int currentani;
    public int previousani;
    
    void Start()
    {
        matPlay = Resources.Load<Material>("Materials/CubeMatPlay");
        matPause = Resources.Load<Material>("Materials/CubeMatPause");
        playing = false;
        cubeAnimator = gameObject.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        cubeAnimator.enabled = false;
        currentani = 1;

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
        if (Physics.Raycast(ray, out hit) && clicked && hit.collider.name == "Cube")
        {
            Debug.Log("Clicked on gameobject: " + hit.collider.name);

            

            if (playing)
            {
                //testing1B.Invoke();
                //cubeAnimator.SetBool("Playing", true);


                //cubeAnimator.enabled = true;
                //cubeAnimator.Play("Bouncing");
                //FindObjectOfType<AudioManager>().Play();
                ////sound.Play();
                //playing = false;

                //object1.GetComponent<MeshRenderer>().material = matPlay;
                //cubeAnimator.SetTrigger("isPlaying");

                Playing();
            }
            else
            {
                //testing2T.Invoke();
                //cubeAnimator.SetBool("Playing", false);


                //cubeAnimator.enabled = false;
                ////sound.Pause();
                //FindObjectOfType<AudioManager>().Pause();
                //playing = true;
                //object1.GetComponent<MeshRenderer>().material = matPause;
                //cubeAnimator.ResetTrigger("isPlaying");
                Pause();
            }

            
            
        }

       
    }

    public void Playing()
    {
        cubeAnimator.enabled = true;
        //cubeAnimator.Play("Bouncing");
        cubeAnimator.Play(tempoAnimation[currentani]);
        FindObjectOfType<AudioManager>().Play();
        //sound.Play();
        playing = false;

        gameObject.GetComponent<MeshRenderer>().material = matPlay;
        cubeAnimator.SetTrigger("isPlaying");
    }

    public void Pause()
    {
        //testing2T.Invoke();
        //cubeAnimator.SetBool("Playing", false);
        cubeAnimator.enabled = false;
        //sound.Pause();
        FindObjectOfType<AudioManager>().Pause();
        playing = true;
        gameObject.GetComponent<MeshRenderer>().material = matPause;
        cubeAnimator.ResetTrigger("isPlaying");
    }



}
