using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float MoveSpeed = 2;
    public float RunSpeed = 5;
    Rigidbody rb = null;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector3(RunSpeed, RunSpeed, 0);
            }
            else {
                rb.velocity = new Vector3(MoveSpeed, MoveSpeed, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector3(RunSpeed, (RunSpeed) * -1, 0);
            }
            else {
                rb.velocity = new Vector3(MoveSpeed, (MoveSpeed) * -1, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector3((RunSpeed) * -1, RunSpeed, 0);
            }
            else {
                rb.velocity = new Vector3((MoveSpeed) * -1, MoveSpeed, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector3((RunSpeed) * -1, (RunSpeed) * -1, 0);
            }
            else {
                rb.velocity = new Vector3((MoveSpeed) * -1, (MoveSpeed) * -1, 0);
            }
        }
        else if (Input.GetKey(KeyCode.W)){
            if (Input.GetKey(KeyCode.LeftShift)){
                rb.velocity = new Vector3(0, RunSpeed, 0);
            }
            else{
                rb.velocity = new Vector3(0, MoveSpeed, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector3(RunSpeed * -1, 0, 0);
            }
            else {
                rb.velocity = new Vector3(MoveSpeed * -1, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector3(0, RunSpeed * -1, 0);
            }
            else {
                rb.velocity = new Vector3(0, MoveSpeed * -1, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector3(RunSpeed, 0, 0);
            }
            else {
                rb.velocity = new Vector3(MoveSpeed, 0, 0);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
