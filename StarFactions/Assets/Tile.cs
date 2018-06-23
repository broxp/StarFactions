using UnityEngine;
using System.Collections;
using System;

public class Tile : MonoBehaviour {
	public int x, y;
	Vector3 firstClick;

	void Update () {
	}

	void OnMouseDown(){
		firstClick = Input.mousePosition;
	}

	void OnMouseUp(){
		var last = Input.mousePosition;
		var dy = Math.Sign(last.y - firstClick.y);
		var dx = Math.Sign(last.x - firstClick.x);
		Board.instance.OnClick (y, x, dy, dx);
	}
}
