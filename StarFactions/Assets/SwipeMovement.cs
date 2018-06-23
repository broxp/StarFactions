using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// https://forum.unity.com/threads/swipe-in-all-directions-touch-and-mouse.165416
public class SwipeMovement : MonoBehaviour
{
	public static string lastSwipe = "";
	public static Vector2 firstPressPos;
	public static Vector2 secondPressPos;
	public static Vector2 currentSwipe;
	public static string debug { get { return currentSwipe + ", " + lastSwipe + ", " + firstPressPos; } }

	static void upSwipe ()
	{
		lastSwipe = "up";
		Board.instance.swipe (lastSwipe, firstPressPos);
	}

	static void leftSwipe ()
	{
		lastSwipe = "left";
		Board.instance.swipe (lastSwipe, firstPressPos);
	}

	static void downSwipe ()
	{
		lastSwipe = "down";
		Board.instance.swipe (lastSwipe, firstPressPos);
	}

	static void rightSwipe ()
	{
		lastSwipe = "right";
		Board.instance.swipe (lastSwipe, firstPressPos);
	}

	void Update ()
	{
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch (0);
			if (t.phase == TouchPhase.Began) {
				//save began touch 2d point
				firstPressPos = new Vector2 (t.position.x, t.position.y);
			}
			if (t.phase == TouchPhase.Ended) {
				//save ended touch 2d point
				secondPressPos = new Vector2 (t.position.x, t.position.y);
                           
				//create vector from the two points
				currentSwipe = secondPressPos - firstPressPos;
               
				//normalize the 2d vector
				currentSwipe.Normalize ();
 
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					upSwipe ();
				}
				if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					downSwipe ();
				}
				if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					leftSwipe ();
				}
				if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					rightSwipe ();
				}
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			//save began touch 2d point
			firstPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		}
		if (Input.GetMouseButtonUp (0)) {
			//save ended touch 2d point
			secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

			//create vector from the two points
			currentSwipe = new Vector2 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			//normalize the 2d vector
			currentSwipe.Normalize ();

			//swipe upwards
			if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				upSwipe ();
			}
			//swipe down
			if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				downSwipe ();
			}
			//swipe left
			if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				leftSwipe ();
			}
			//swipe right
			if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				rightSwipe ();
			}
		}
	}
}
