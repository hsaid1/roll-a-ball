using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void start(){
		count = 0;
		setCountText();
		winText.text = "";
	}
	
	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Pickup"){
			other.gameObject.SetActive(false);
			count++;
			setCountText();
		}
	}
	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 10) {
			winText.text = "YOU WIN!";
		}
	}

}
