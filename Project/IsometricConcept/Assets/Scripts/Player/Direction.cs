using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {

    public Vector2 dir = new Vector2(0,1);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            dir = new Vector2(1, 1);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            dir = new Vector2(1, -1);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            dir = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            dir = new Vector2(-1, -1);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            dir = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dir = new Vector2(-1, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir = new Vector2(0, -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir = new Vector2(1, 0);
        }
        Selection.direction = dir;
        CheatyCheatyDestroy.direction = dir;
    }
}
