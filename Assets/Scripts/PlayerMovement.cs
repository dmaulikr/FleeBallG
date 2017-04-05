using UnityEngine;
using System.Collections;

/// <summary>
/// Player movement, follow mouse/finger
/// </summary>
public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed;
	Vector3 mousePosition;
	private bool isDown;
	public float offset;

	void Start () 
	{
		isDown = false;
	}

	void Update () 
	{
		if(isDown)
		{
			transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y + offset)), moveSpeed);
		}
		if(transform.position.x > 3.52f) 
		{
			transform.position = new Vector3(3.52f, transform.position.y, 0);
		}
		if(transform.position.x < -3.52f) 
		{
			transform.position = new Vector3(-3.52f, transform.position.y, 0);
		}
		if(transform.position.y > 4.61f)
		{
			transform.position = new Vector3(transform.position.x, 4.61f, 0);
		}
		if(transform.position.y < -4.61f)
		{
			transform.position = new Vector3(transform.position.x, -4.61f, 0);
		}
	}

	void OnMouseDown ()
	{
		isDown = true;
	}

	void OnMouseUp ()
	{
		isDown = false;
	}
}













