
#if UNITY_EDITOR_64
using NUnit.Framework;
using System;

namespace AssemblyCSharp
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void TestCase ()
		{
			var r = new Ruby ();
			var occ = new int[100];
			for (int i = 0; i < 1000; i++) {
				occ [r.randColor ()]++;
			}
			for (int i = 0; i < 7; i++) {
				Console.WriteLine ("Color " + i + ": " + occ [i]);
			}
			//r.prepare ();
			//r.puts_field ();
		}
	}
}
#endif
