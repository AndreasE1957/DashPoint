using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{

    public Rigidbody head;
    public bool IsGrounded;
    public float holdForce;
    public float jump;
    public static bool active;
    private void Start()
    {
        GlobalVariables.active = true;
    }

    private void Update()
    {
        if (GlobalVariables.active) { 
        Vector3 fl = new Vector3(0, 1, 0);
        head.AddForce(fl * holdForce);

        if (IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                Vector3 jumpA = new Vector3(0, 1, 0);
                head.AddForce(jumpA * jump);

            }


        }
    }
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag != "Player")
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;
    }
}
