using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(speed, 0, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.position -= new Vector3(speed, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, speed, 0);
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= new Vector3(0, speed, 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Point")
        {
            GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
            gameController.SetScore(10);

            Destroy(other.gameObject);
        }
    }
}
