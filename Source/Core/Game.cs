namespace Not_Celeste.Core;

internal class Game
{
	public Dictionary<Type, List<IComponent>> ECS;

	public void Run()
	{
		Console.WriteLine("Hello!");
	}
}