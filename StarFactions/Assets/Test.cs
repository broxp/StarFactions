
#if UNITY_EDITOR_64
using NUnit.Framework;
using System;
using UnityEngine;

namespace AssemblyCSharp
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void TestCase1 ()
		{
			// counting sort to check weighted rnd number gen
			var r = new Ruby ();
			var occ = new int[Ruby.NUMBER_OF_COLORS];
			for (int i = 0; i < 1000; i++) {
				occ [r.randColor ()]++;
			}
			for (int i = 0; i < 7; i++) {
				Console.WriteLine ("Color " + i + ": " + occ [i]);
			}
			//r.prepare ();
			//r.puts_field ();
		}

		[Test]
		public void TestCase2 ()
		{
			foreach (var item in new []{
				new []{0,0,  0,   0,  0,0},
				new []{0,0,  10, 10,  0,0},
				new []{0,0,   0, 10,  0,1},
				new []{0,0,   0, -3,  0,-1},
				new []{0,0,   2, -3,  0,-1},
			}) {
				var first = new Vector2 (item [0], item [1]);
				var last = new Vector2 (item [2], item [3]);
				int dx;
				var expDx = item [4];
				var expDy = item [5];
				var debug = "Test case: from " + first + " to " + last +" should yield dy: "+expDy+", dx: "+expDx;
				var dy = Helper.calcDelta (first, last, out dx);
				Assert.AreEqual (expDy, dy, "dy: " + debug);
				Assert.AreEqual (expDx, dx, "dy: " + debug);
			}
		
		}
	}

}
#endif
