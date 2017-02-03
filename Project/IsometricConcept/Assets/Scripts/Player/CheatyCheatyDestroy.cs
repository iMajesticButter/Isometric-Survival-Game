using UnityEngine;
using System.Collections;

public class CheatyCheatyDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Endlesness.tileDictionary[new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y))].RemoveObject(new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)));
            Debug.Log(new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)));
        }
	}
}
