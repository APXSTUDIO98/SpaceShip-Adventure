using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeFinger : MonoBehaviour
{
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	public float speed;
	public Rigidbody2D playerRB;

	public GameObject left;
	public GameObject Middle;
	public GameObject right;
    private void Update()
    {
		MobSwipe();
		MouseSwipe();
    }
  public void MouseSwipe()
  {
		if (Input.GetMouseButtonDown(0))
		{
			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}
		if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

          //  create vector from the two points

                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

          //  normalize the 2d vector

                currentSwipe.Normalize();
		

			Temp();
        }
    }
    public void MobSwipe()
	{
		if (Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}
			if (t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x, t.position.y);

				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				//normalize the 2d vector
				currentSwipe.Normalize();
	
				Temp();
			}
		}
	}

	public void Temp()
    {
		if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
		{
			//this.transform.position += Vector3.left * this.speed * Time.deltaTime;
			if (transform.position == Middle.transform.position)

			{
				transform.position = Vector3.MoveTowards(transform.position, left.transform.position, speed);
				s();
			}
			if (transform.position == right.transform.position)
			{

				transform.position = Vector3.MoveTowards(transform.position, Middle.transform.position, speed);
				s();
			}

			Debug.Log("left swipe");
		}
		// swipe right

		if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
		{
			if (transform.position == Middle.transform.position)
			{
				transform.position = Vector3.MoveTowards(transform.position, right.transform.position, speed);
				s();
			}
			if (transform.position == left.transform.position)
			{
				transform.position = Vector3.MoveTowards(transform.position, Middle.transform.position, speed);
				s();
			}
			//	playerRB.velocity = new Vector2(-1 * speed * Time.fixedDeltaTime, playerRB.velocity.y);
			Debug.Log("right swipe");
		}
	}
	public void s()
    {
		AudioManager.instance.Play("swipe");
	}
}
