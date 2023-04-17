namespace Not_Celeste.System;

internal class TestSystem : ISystem {
	public override void Process(double delta)
	{
		foreach(GameObject i in SceneTree.GetGameObjects(new Type[] {typeof(ComponentTemplate), typeof(ComponentTemplate)}))
		{
			Console.WriteLine("a Test Component");
		}
	}
}