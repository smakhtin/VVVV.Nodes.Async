using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.Async
{
	[PluginInfo(Name = "AsValue", Category = "String", Version = "Async NonThreaded")]
	public 	class AsValueSyncNode : IPluginEvaluate
	{
		[Input("Input")] 
		private IDiffSpread<string> FInput;

		[Output("Output")] 
		private ISpread<double> FOutput;

		readonly AsValueProcessor FProcessor = new AsValueProcessor();
 
		public void Evaluate(int spreadMax)
		{
			FOutput.SliceCount = spreadMax;

			FProcessor.Process(FInput, spreadMax);

			FOutput.AssignFrom(FProcessor.Output);
		}
	}
}
