using UnityEngine;
using System.Collections;
using System;

public class Tile : MonoBehaviour
{
	public TileData data;
	Vector3 firstClick;

	void Update ()
	{
	}

	void OnMouseDown ()
	{
		firstClick = Input.mousePosition;
		data.on = !data.on;
		Board.instance.hasChanges = true;
	}

	void OnMouseUp ()
	{
		data.on = false;
		var last = Input.mousePosition;
		// 0 (45) 90 (135) 180 (225) 270 (315) 360
		var angle = (-(Mathf.Atan2 (last.y - firstClick.y, last.x - firstClick.x) * 180 / Mathf.PI) + 90 + 360) % 360; 
		var dy = (angle > 315 || angle < 45) ? 1 : (angle > 135 && angle < 225) ? -1 : 0; //Math.Sign (last.y - firstClick.y);
		var dx = (angle > 45 && angle < 135) ? 1 : (angle > 225 && angle < 315) ? -1 : 0; //Math.Sign (last.x - firstClick.x);
		print (angle + " -> dy " + dy + ", dx " + dx);
		Board.instance.OnClick (data.y, data.x, dy, dx);
	}
}
