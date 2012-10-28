using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.Async
{
	[PluginInfo(Name = "Separate", Category = "String", Version = "Async NonThreaded")]
	public class SeparateSyncNode : IPluginEvaluate
	{
		[Input("Input")] 
		private ISpread<string> FInput;

		[Input("Intersperse")] 
		private ISpread<string> FIntersperse;

		[Output("Output")]
		private ISpread<ISpread<string>> FOutput;

		readonly SeparateProcessor FProcessor = new SeparateProcessor();

		public void Evaluate(int spreadMax)
		{
			FOutput.SliceCount = spreadMax;

			FProcessor.Process(FInput, FIntersperse, spreadMax);

			FOutput.AssignFrom(FProcessor.Output);
		}
	}
}
