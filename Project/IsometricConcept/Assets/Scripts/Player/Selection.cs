using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

    public GameObject Cursor;
    public static Vector2 direction = new Vector2(0,1);

    // Use this for initialization
    void Start () {

        Cursor = GameObject.Instantiate(Cursor);

	}
	
	// Update is called once per frame
	void Update () {

        Cursor.transform.position = new Vector3(Mathf.RoundToInt(transform.position.x + direction.x), Mathf.RoundToInt(transform.position.y + direction.y), -16);

	}
}
