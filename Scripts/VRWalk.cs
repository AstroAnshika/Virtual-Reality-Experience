using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWalk : MonoBehaviour
{ 
    // How fast to move
    public float speed = 3.0f;
    // Shoulg I move forward or not
    public bool moveForward;
    //Character controller script
    private CharacterController controller;
    //GVR Viewer Script
    private GvrViewer gvrViewer;
    //VR Head position
    private Transform vrHead;

    // Start is called before the first frame update
    void Start()
    {
        //finds the character controller component
        controller = GetComponent<CharacterController>();
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        vrHead = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveForward = !moveForward;
        }
        if (moveForward)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);

        }

    }
}

