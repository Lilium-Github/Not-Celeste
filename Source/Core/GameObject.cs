namespace Not_Celeste.Core;

/// <summary>
/// Class <c>GameObject</c> Handles a tree-like data structure of other <c>GameObjects</c>
/// </summary>
internal class GameObject {

	public static GameObject SceneRoot; // Maybe this should be in Game?

	// Members (these should all be private)
	private GameObject? _parent = null;
	private readonly List<GameObject> _children = new();

	// Properties (these should all be public)
	public required string Name { get; init; }

	// Methods

	/// <summary>
	/// Adds the given GameObject as the current instance's child and updates it's parent to be the current instance
	/// </summary>
	/// <param name="child"></param>
	public void addChild(GameObject child) {
		if (_children.Contains(child) || child._parent is not null) {
			throw new Exception("Attempting to add a gameobject that already has a parent"); //TODO: replace this with a less general exception type
		} else {
			_children.Add(child);
			child._parent = this;
		}
	}
}
