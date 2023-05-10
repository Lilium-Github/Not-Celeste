namespace Not_Celeste.Core;

internal class Game
{
	private readonly List<GameSystem> _gameSystems = new();

	public Game() {
		_gameSystems.Add(new WASDSystem());

		_gameSystems.Add(new DrawCollisionBos());

		SceneTree.SceneRoot.AddChild(new GameObject());
		SceneTree.SceneRoot.Children[^1].AddComponent(new CollisionArea(){Bounds = new(1)});
		SceneTree.SceneRoot.Children[^1].AddComponent(new Transform2D(){Position = new(400,400)});
		SceneTree.SceneRoot.Children[^1].AddComponent(new WASDComponents());

		GraphicsDevice.Window = new(new(800,800), "Not_Celeste");
		
		Keyboard.IsKeyPressed(Keyboard.Key.A);
		
		GraphicsDevice.Window.Closed += OnClose;
		GraphicsDevice.Window.KeyPressed +=(args,eve)=>{
			if(eve.Code == Keyboard.Key.Escape){
				GraphicsDevice.Window.Close();
			}
		};
	}

	public void Run() {
		var clock = new SFML.System.Clock();

		while (GraphicsDevice.Window.IsOpen) {
			GraphicsDevice.Window.DispatchEvents();

			var delta = clock.Restart().AsSeconds();
			foreach (GameSystem gameSystem in _gameSystems) {
				gameSystem.Process(delta);
			}
		}
	}

	public void OnClose(object? sender, EventArgs e)
	{
		if (sender is Window window) {
			window.Close();
		}
	}
}