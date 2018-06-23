using UnityEngine;
using System.Collections;
using System;

public class Tile : MonoBehaviour
{
	public TileData data;
	TileData startedWith;
	Vector3 firstClick;

	void Update ()
	{
	}

	void OnMouseDown ()
	{
		firstClick = Input.mousePosition;
		data.on = !data.on;
		startedWith = data;
		Board.instance.hasChanges = true;
	}

	void OnMouseUp ()
	{
		data.on = false;
		var last = Input.mousePosition;
		int dx;
		var dy = Helper.calcDelta (firstClick, last, out dx); 
		Board.instance.OnClick (startedWith.y, startedWith.x, dy, dx);
	}
}
