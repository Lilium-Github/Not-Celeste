namespace Not_Celeste.Components;

internal class PhysicsProperties : Component {
	public required float Mass { get; set; }
	public Vector2f Velocity { get; set; } = new(0, 0);
	public Vector2f Force { get; set; } = new(0, 0);
	public Vector2f Impulse{ get; set; } = new(0, 0);
}