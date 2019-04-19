using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //Speed is accessable to all
    public float speed;
    public float error;
    private Rigidbody move;
    public float gravity;
	private Vector3 moveDir = Vector3.zero;
    public static bool active; 
    void Start()
    {
        active = true;

        move = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariables.active)
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0);
            move.AddForce(movement * speed);

            //Rotation fixing


        }


        
    }


}
