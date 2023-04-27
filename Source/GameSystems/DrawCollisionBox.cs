namespace Not_Celeste.GameSystems;

internal class DrawCollisionBos : GameSystem {
	//not done, but is usefull for knowing the position
	public override void Process(double delta)
	{
		GraphicsDevice.Window.Clear();

		foreach(GameObject i in SceneTree.GetGameObjects(new Type[] {typeof(Transform2D), typeof(CollisionArea)}))
		{
			//get collision area done and i will have the rectangles match them up;

			var shape = new SFML.Graphics.RectangleShape(new Vector2f(4,4));
			shape.FillColor = SFML.Graphics.Color.White;
			shape.Position = (((Transform2D)i[typeof(Transform2D)]).Position);
			GraphicsDevice.Window.Draw(shape);
		}
		GraphicsDevice.Window.Display();
	}
}