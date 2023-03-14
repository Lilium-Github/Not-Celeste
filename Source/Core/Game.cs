namespace Not_Celeste.Core;

internal class Game
{
	public Dictionary<IComponent, List<IComponent?>> ECS = new();

	public void Run()
	{
		Console.WriteLine("Hello!");
	}
}