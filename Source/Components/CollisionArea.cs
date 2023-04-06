namespace Not_Celeste.Components;

internal class CollisionArea : Component {
	public List<GameObject> CollidedObjects { get; set; } = new();
	public required List<FloatRect> Bounds { get; set; }
}
