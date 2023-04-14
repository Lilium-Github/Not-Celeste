namespace Not_Celeste.Components;

internal class Transform2D : Component {
	public required Vector2f Position { get; set; }

	public Transform2D Copy() {
		var targPos = Position;
		return new Transform2D() {
			Position = targPos
		};
	}

	public static Transform2D operator +(Transform2D a, Transform2D b) {
		return new Transform2D()
		{
			Position = a.Position + b.Position
		};
	}

	public static Transform2D operator -(Transform2D a, Transform2D b) {
		return new Transform2D()
		{
			Position = a.Position - b.Position
		};
	}
}
