using System.Globalization;
using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.Async
{
	public class AsValueProcessor
	{
		public Spread<double> Output { get; private set; }

		public AsValueProcessor()
		{
			Output = new Spread<double>(1);
		}

		public void Process(ISpread<string> input, int spreadMax)
		{
			Output.SliceCount = spreadMax;

			for (int i = 0; i < spreadMax; i++)
			{
				Output[i] = double.Parse(input[i], CultureInfo.InvariantCulture);
			}
		}
	}
}
