namespace Not_Celeste.Utils;

/// <summary>
/// Contains various utility functions relating to the Transform2D class.
/// </summary>
internal static class Transform2DUtils {
	/// <summary>
	/// Gets the global Transform2D of a GameObject.
	/// </summary>
	/// <param name="target"></param>
	/// <returns></returns>
	public static Transform2D GetGlobalTransform2D(GameObject target) {
		if (System.Object.ReferenceEquals(target, SceneTree.SceneRoot)) {
			if (target.Components.ContainsKey(typeof(Transform2D))) {
				return ((Transform2D) target[typeof(Transform2D)]).Copy();
			} else return new Transform2D() {Position = new(0, 0)};
		} else if (target.Parent != null) {
			if (target.Components.ContainsKey(typeof(Transform2D))) {
				return ((Transform2D) target[typeof(Transform2D)]) + GetGlobalTransform2D(target.Parent);
			} else return GetGlobalTransform2D(target.Parent);
		} else {
			throw new ArgumentException("Attemted to get the global transform of something in a disconnected tree!");
		}
	}
}