namespace Not_Celeste.Core;

/// <summary>
/// Class <c>GameObject</c> Handles a tree-like data structure of other <c>GameObjects</c>
/// </summary>
internal class GameObject {
	// Members (these should all be private)
	private GameObject? _parent = null;
	private readonly List<GameObject> _children = new();
	private readonly Dictionary<Type, Component> _components = new();

	//////// Properties //////
	public GameObject? Parent {
		get {
			return _parent;
		}
	}

	public List<GameObject> Children {
		get {
			return new(_children);
		}
	}

	/// <summary>
	/// Returns a COPY of the GameObject's internal component dictionary. To access or alter components, index into the GameObject directly.
	/// </summary>
	/// <value></value>
	public Dictionary<Type, Component> Components {
		get {
			return new(_components);
		}
	}

	public Component this[Type i] {
		get {
			return _components[i];
		}
		set {
			if (i != value.GetType()) {
				throw new ArgumentException("Attemped to set a value not of indexed type");
			} else {
				_components[i] = value;
			}
		}
	}

	//////// Methods ////////
	/// <summary>
	/// Adds the given GameObject as the current instance's child and updates it's parent to be the current instance
	/// </summary>
	/// <param name="child"></param>
	public void AddChild(GameObject child) {
		if (child._parent is not null) {
			throw new ArgumentException("Attempted to add a gameobject as a child that already has a parent!");
		} else {
			_children.Add(child);
			child._parent = this;
		}
	}

	/// <summary>
	/// Removes the given GameObject from the current instance's children and updates it's parent to be null
	/// </summary>
	/// <param name="child"></param>
	public void RemoveChild(GameObject child)
	{
		if (!_children.Contains(child)) {
			throw new ArgumentException("Attempted to remove a gameobject from children that is not a child!");
		} else {
			Children.Remove(child);
			child._parent = null;
		}
	}

	/// <summary>
	/// Registers the given component to the current instance
	/// </summary>
	/// <param name="component"></param>
	public void AddComponent(Component component) {
		if (_components.ContainsKey(component.GetType())) {
			throw new ArgumentException("Attempted to add a component that is already registered!");
		}
		else {
			_components[component.GetType()] = component;
		}
	}

	/// <summary>
	/// Unegisters the given component from the current instance
	/// </summary>
	/// <param name="component"></param>
	public void RemoveComponent(Component component) {
		if (!_components.ContainsKey(component.GetType())) {
			throw new ArgumentException("Attempted to remove a component that is not registered!");
		} else {
			_components.Remove(component.GetType());
		}
	}
}
