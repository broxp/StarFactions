using System;
using UnityEngine;

public static class Helper
{
	/// 0 (45) 90 (135) 180 (225) 270 (315) 360
	public static int calcDelta (Vector3 fromVec, Vector3 toVec, out int dx)
	{
		if (fromVec == toVec) {
			dx = 0;
			return 0;
		}
		var angle = (-(Mathf.Atan2 (toVec.y - fromVec.y, toVec.x - fromVec.x) * 180 / Mathf.PI) + 90 + 360) % 360;
		var dy = (angle > 315 || angle < 45) ? -1 : (angle > 135 && angle < 225) ? 1 : 0;
		dx = (angle > 45 && angle < 135) ? 1 : (angle > 225 && angle < 315) ? -1 : 0;
		Console.WriteLine (angle + " -> dy " + dy + ", dx " + dx);
		return dy;
	}
}
