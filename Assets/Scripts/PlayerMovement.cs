using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public static bool isPlayerDead = false;
    public GameObject player;
	// Use player for initialization
    Rigidbody rb;
    float speed =50f;
	void Awake()
    {
        
        Screen.orientation = ScreenOrientation.LandscapeLeft;
      rb = player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

    { 
        
        float x1 = 0;
		float x = Input.GetAxis ("Horizontal") * Time.fixedDeltaTime * speed;
		Vector3 newPosition = rb.position + Vector3.right * x;
		newPosition.x = Mathf.Clamp (newPosition.x, -13f, 13f);
		rb.MovePosition (newPosition);

		if (Input.GetMouseButton (0) && Input.mousePosition.x < Screen.width / 2)
        {
			x1 = -1f;
			Vector3 newPosition1 = rb.position + Vector3.right * x1;
			newPosition1.x = Mathf.Clamp (newPosition1.x, -13f, 13f);
			rb.MovePosition (newPosition1);

		}

		if (Input.GetMouseButton (0) && Input.mousePosition.x > Screen.width / 2)
        {
			x1 = 1f;
			Vector3 newPosition1 = rb.position + Vector3.right * x1;
			newPosition1.x = Mathf.Clamp (newPosition1.x, -13f, 13f);
			rb.MovePosition (newPosition1);
		}
    }

        // if(Input.GetKey(KeyCode.LeftArrow))
        // player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x -0.5f, -10f, 10f), player.transform.position.y, player.transform.position.z);
        // if (Input.GetKey(KeyCode.RightArrow))
        // player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x + 0.5f, -10f, 10f), player.transform.position.y, player.transform.position.z);
        // if (Input.GetKey(KeyCode.UpArrow))
        //     player.transform.position = new Vector3( player.transform.position.x, Mathf.Clamp(player.transform.position.y + 0.5f, -4f, 4f), player.transform.position.z);
        // if (Input.GetKey(KeyCode.DownArrow))
        //     player.transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y - 0.5f, -4f, 4f), player.transform.position.z);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            isPlayerDead = true; 
        }
    }

}
