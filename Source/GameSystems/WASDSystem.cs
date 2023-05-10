namespace Not_Celeste.GameSystems;
internal class WASDSystem : GameSystem{
	public override void Process(double delta) {		
		foreach(var gameObject in SceneTree.GetGameObjects(new Type[] {typeof(Transform2D), typeof(WASDComponents)})){
			// var transform2D =Transform2DUtils.GetGlobalTransform2D(gameObject);
			var transform2D = (((Transform2D)gameObject[typeof(Transform2D)]));
			if(Keyboard.IsKeyPressed(Keyboard.Key.A)){
				transform2D.Position =new Vector2f(transform2D.Position.X - (float) delta*10, transform2D.Position.Y);
			}
			if(Keyboard.IsKeyPressed(Keyboard.Key.W)){
				transform2D.Position =new Vector2f(transform2D.Position.X, transform2D.Position.Y - (float) delta*10);

			}
			if(Keyboard.IsKeyPressed(Keyboard.Key.S)){
				transform2D.Position =new Vector2f(transform2D.Position.X, transform2D.Position.Y - (float) delta*10);

			}
			if(Keyboard.IsKeyPressed(Keyboard.Key.D)){
				transform2D.Position =new Vector2f(transform2D.Position.X + (float) delta*10, transform2D.Position.Y);

			}
		}
	}
};