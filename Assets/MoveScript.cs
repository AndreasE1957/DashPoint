using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //Speed is accessable to all
    public float speed;
    private Rigidbody move;
    public float error;

    void Start()
    {
    move = GetComponent<Rigidbody> ();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("d")) 
        {
            Vector3 movement = new Vector3(1500, 0);
        move.AddForce(movement*speed);

            //Rotation fixing
            if (System.Math.Abs(move.rotation.eulerAngles.y - 180) > error )
            {
                Vector3 rotate = new Vector3(0, (180 - move.rotation.eulerAngles.y), 0);
                move.AddTorque(rotate * 10);
            }

        }


        if (Input.GetKeyDown("a"))
        {
            Vector3 movement = new Vector3(-1500, 0);
            move.AddForce(movement * speed);

            //Rotation fixing
            if (System.Math.Abs(move.rotation.eulerAngles.y) > error)
            {

                Vector3 rotate = new Vector3(0, move.rotation.eulerAngles.y-180, 0);
                move.AddTorque(rotate * 600);
            }

        }

    }
}
