namespace Not_Celeste.System;

internal class TestSystem : ISystem {
	public void Process(double delta)
	{
		foreach(GameObject i in SceneTree.GetGameObjects(new Type[] {typeof(TestComponent), typeof(OtherTestComponent)}))
		{
			var test = ((TestComponent) i[typeof(TestComponent)]);

			test.TestInt += ((OtherTestComponent) i[typeof(OtherTestComponent)]).TestIncrement;

			i[typeof(TestComponent)] = test;

			Console.WriteLine(((TestComponent) i[typeof(TestComponent)]).TestInt);
		}
	}
}