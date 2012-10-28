using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.Async
{
	public class SeparateProcessor
	{
		public Spread<Spread<string>> Output { get; private set; }

		public SeparateProcessor()
		{
			Output = new Spread<Spread<string>>(1);
		}

		public void Process(ISpread<string> input, ISpread<string> separator, int spreadMax)
		{
			Output.SliceCount = spreadMax;

			for (int i = 0; i < spreadMax; i++)
			{
				string[] strings = input[i].Split(separator[i].ToArray());

				if (!strings.Any()) continue;
				
				if(Output[i] == null) Output[i] = new Spread<string>(1);

				Output[i].AssignFrom(strings);
			}
		}
	}
}
