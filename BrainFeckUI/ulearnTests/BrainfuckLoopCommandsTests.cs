﻿using System;
using System.Text;
using NUnit.Framework;

namespace func.brainfuck
{
	[TestFixture]
	public class BrainfuckLoopCommandsTests
	{
		[Test]
		public void Loops()
		{
			Assert.AreEqual("\x0", Run("[+.]."));
			Assert.AreEqual("\x1\x0", Run("+[.-]."));
			Assert.AreEqual("\x3\x2\x1\x0", Run("+++[.-]."));
		}

        [Test]
        public void SimpleLoop()
        {
            Assert.AreEqual("A", Run("++++++++[>++++++++<-]>+."));
        }

        [Test]
        public void ZDoubleLoop()
        {
            Assert.AreEqual("\0", Run("++[-]++[-]."));
            Assert.AreEqual("\0", Run("+[+[-]]."));
        }

        [Test]
		public void NestedLoops()
		{
			Assert.AreEqual("\x4", Run("++[>++[>+<-]<-]>>."));
		}

		[Test]
		public void HelloWorldWithLoops()
		{
			Assert.AreEqual("Hello World!\n", Run(@"
++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++
.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.
------.--------.>+.>."));
		}

		[Test]
		public void BottlesOfBeer()
		{
			var text = Run(@"
>+++++++++[<+++++++++++>-]<[>[-]>[-]<<[>+>+<<-]>>[<<+>>-]>>>
[-]<<<+++++++++<[>>>+<<[>+>[-]<<-]>[<+>-]>[<<++++++++++>>>+<
-]<<-<-]+++++++++>[<->-]>>+>[<[-]<<+>>>-]>[-]+<<[>+>-<<-]<<<
[>>+>+<<<-]>>>[<<<+>>>-]>[<+>-]<<-[>[-]<[-]]>>+<[>[-]<-]<+++
+++++[<++++++<++++++>>-]>>>[>+>+<<-]>>[<<+>>-]<[<<<<<.>>>>>-
]<<<<<<.>>[-]>[-]++++[<++++++++>-]<.>++++[<++++++++>-]<++.>+
++++[<+++++++++>-]<.><+++++..--------.-------.>>[>>+>+<<<-]>
>>[<<<+>>>-]<[<<<<++++++++++++++.>>>>-]<<<<[-]>++++[<+++++++
+>-]<.>+++++++++[<+++++++++>-]<--.---------.>+++++++[<------
---->-]<.>++++++[<+++++++++++>-]<.+++..+++++++++++++.>++++++
++[<---------->-]<--.>+++++++++[<+++++++++>-]<--.-.>++++++++
[<---------->-]<++.>++++++++[<++++++++++>-]<++++.-----------
-.---.>+++++++[<---------->-]<+.>++++++++[<+++++++++++>-]<-.
>++[<----------->-]<.+++++++++++..>+++++++++[<---------->-]<
-----.---.>>>[>+>+<<-]>>[<<+>>-]<[<<<<<.>>>>>-]<<<<<<.>>>+++
+[<++++++>-]<--.>++++[<++++++++>-]<++.>+++++[<+++++++++>-]<.
><+++++..--------.-------.>>[>>+>+<<<-]>>>[<<<+>>>-]<[<<<<++
++++++++++++.>>>>-]<<<<[-]>++++[<++++++++>-]<.>+++++++++[<++
+++++++>-]<--.---------.>+++++++[<---------->-]<.>++++++[<++
+++++++++>-]<.+++..+++++++++++++.>++++++++++[<---------->-]<
-.---.>+++++++[<++++++++++>-]<++++.+++++++++++++.++++++++++.
------.>+++++++[<---------->-]<+.>++++++++[<++++++++++>-]<-.
-.---------.>+++++++[<---------->-]<+.>+++++++[<++++++++++>-
]<--.+++++++++++.++++++++.---------.>++++++++[<---------->-]
<++.>+++++[<+++++++++++++>-]<.+++++++++++++.----------.>++++
+++[<---------->-]<++.>++++++++[<++++++++++>-]<.>+++[<----->
-]<.>+++[<++++++>-]<..>+++++++++[<--------->-]<--.>+++++++[<
++++++++++>-]<+++.+++++++++++.>++++++++[<----------->-]<++++
.>+++++[<+++++++++++++>-]<.>+++[<++++++>-]<-.---.++++++.----
---.----------.>++++++++[<----------->-]<+.---.[-]<<<->[-]>[
-]<<[>+>+<<-]>>[<<+>>-]>>>[-]<<<+++++++++<[>>>+<<[>+>[-]<<-]
>[<+>-]>[<<++++++++++>>>+<-]<<-<-]+++++++++>[<->-]>>+>[<[-]<
<+>>>-]>[-]+<<[>+>-<<-]<<<[>>+>+<<<-]>>>[<<<+>>>-]<>>[<+>-]<
<-[>[-]<[-]]>>+<[>[-]<-]<++++++++[<++++++<++++++>>-]>>>[>+>+
<<-]>>[<<+>>-]<[<<<<<.>>>>>-]<<<<<<.>>[-]>[-]++++[<++++++++>
-]<.>++++[<++++++++>-]<++.>+++++[<+++++++++>-]<.><+++++..---
-----.-------.>>[>>+>+<<<-]>>>[<<<+>>>-]<[<<<<++++++++++++++
.>>>>-]<<<<[-]>++++[<++++++++>-]<.>+++++++++[<+++++++++>-]<-
-.---------.>+++++++[<---------->-]<.>++++++[<+++++++++++>-]
<.+++..+++++++++++++.>++++++++[<---------->-]<--.>+++++++++[
<+++++++++>-]<--.-.>++++++++[<---------->-]<++.>++++++++[<++
++++++++>-]<++++.------------.---.>+++++++[<---------->-]<+.
>++++++++[<+++++++++++>-]<-.>++[<----------->-]<.+++++++++++
..>+++++++++[<---------->-]<-----.---.+++.---.[-]<<<]");

			Assert.IsTrue(text.Contains("99 Bottles of beer on the wall"));
			Assert.IsTrue(text.Contains("Take one down and pass it around"));
			Assert.IsTrue(text.Contains("43 Bottles of beer on the wall"));
			Assert.IsTrue(text.Contains("1 Bottle of beer on the wall"));
			Assert.IsTrue(text.Contains("0 Bottles of beer on the wall"));
		}

		[Test]
		public void APairBracetsDictionaryIsNotStatic()
		{
			Run(@"
++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++
.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.
------.--------.>+.>.");
			
			Assert.AreEqual("Hello World!\n", Run(@"
++++++++++[>++++<>+++>++++++++++>+++>+<<<<-]>++
.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.
------.--------.>+.>."));
		}

		[Test]
		[MaxTime(1000)]
		public void LoopsPerformance()
		{
			var s = new string('.', 10000);
			Run("0[->0[->0[->[" + s + "]<]<]<]");
		}

		[Test]
		[MaxTime(1000)]
		public void NestedLoopsPerformance()
		{
			var s = new StringBuilder();
			var size = 50000;
			for (int i = 0; i < size; i++) s.Append("+[->.");
			s.Append("+[-]<");
			for (int i = 0; i < size; i++) s.Append("]<");
			var program = s.ToString();
			Run(program);
		}

		[Test]
		[MaxTime(2000)]
		public void NestedLoopsPerformance2()
		{
			var s = new StringBuilder();
			var size = 30000;
			for (int i = 0; i < size; i++) s.Append("++>");
			for (int i = 0; i < size; i++) s.Append("<[-");
			for (int i = 0; i < size; i++) s.Append("]>");
			var program = s.ToString();
			Run(program);
		}

		private string Run(string program, string input = "")
		{
			return Brainfuck.Run(program, input);
		}
	}
}