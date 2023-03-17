namespace Not_Celeste.Core;

internal class Game
{
	private readonly List<ISystem> _systems = new();

	public Game()
	{
		_systems.Add(new TestSystem());

		SceneTree.SceneRoot.AddComponent(new TestComponent() { TestInt = 0 });
		SceneTree.SceneRoot.AddComponent(new OtherTestComponent() { TestIncrement = 1 });

		Console.WriteLine("Initialization Complete");
	}

	public void Run()
	{
		for ( int i = 0; i < 10; i++) {
			foreach (ISystem j in _systems) {
				j.Process(0);
			}
		}
	}
}