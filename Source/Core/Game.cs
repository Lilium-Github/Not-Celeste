namespace Not_Celeste.Core;

internal class Game
{
	private readonly List<GameSystem> _gameSystems = new();

	public Game() {
		GraphicsDevice.Window = new(new(), "Not_Celeste");

		GraphicsDevice.Window.Closed += OnClose;
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