using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayPause : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 clickPos;
    bool clicked;
    public GameObject object1;
    public Renderer rende;
    public Material matPlay;


    void Start()
    {
        matPlay = Resources.Load("./Material/CubeMatPlay.mat", typeof(Material)) as Material;
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
            //rende.material = matPlay;
            object1.GetComponent<MeshRenderer>().material = matPlay;
        }

       
    }




}
