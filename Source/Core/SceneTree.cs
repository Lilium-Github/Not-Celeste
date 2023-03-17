namespace Not_Celeste.Core;

internal static class SceneTree {
	private static GameObject _sceneRoot = new();

	public static GameObject SceneRoot {
		get {
			return _sceneRoot;
		}
	}
	
	public static List<GameObject> GameObjectsFlatList {
		get {
			var output = new List<GameObject>() {_sceneRoot};
			var currentIndex = 0;

			while (output.Count > currentIndex) {
				foreach (GameObject i in output[currentIndex].Children) {

					output.Add(i);
				}
				currentIndex += 1;
			}

			return output;
		}
	}
	
	/// <summary>
	/// Changes the scene root to the new object. WARNING: OLD SCENE TREE IS NOT PRESERVED AUTOMATICALLY, STORE PREVIOUS ROOT IF NEEDED
	/// </summary>
	/// <param name="newRoot"></param>
	public static void SetSceneRoot(GameObject newRoot) {
		if (newRoot.Parent is not null) {
			throw new ArgumentException("Tried to change scene root to a GameObject with a parent");
		} else {
			_sceneRoot = newRoot;
		}
	}

	public static List<GameObject> GetGameObjects(Type[] MatchTypes)  {
		var gameObjects = GameObjectsFlatList;
		var output = new List<GameObject>();

		foreach (GameObject i in gameObjects) {
			var shouldInclude = true;

			foreach (Type j in MatchTypes) {
				if (!i.Components.ContainsKey(j)) {
					shouldInclude = false;
				}
			}

			if (shouldInclude) {
				output.Add(i);
			}
		}
		return output;
	}
}