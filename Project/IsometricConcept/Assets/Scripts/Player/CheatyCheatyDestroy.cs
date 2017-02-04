using UnityEngine;
using System.Collections;

public class CheatyCheatyDestroy : MonoBehaviour {

    public static Vector2 direction = new Vector2(0,1);

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Endlesness.tileDictionary[new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)) + direction].RemoveObject(new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)) + direction);
            Debug.Log(new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)));
        }
	}
}
