namespace Not_Celeste.Core;

internal class Game
{
	private readonly List<GameSystem> _gameSystems = new();

	public Game() {
		_gameSystems.Add(new DrawCollisionBos());
		GraphicsDevice.Window = new(new(800,800), "Not_Celeste");

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