namespace Not_Celeste.GameSystems;

internal class Collision : GameSystem {
	public override void Process(double Delta) {
		foreach (GameObject gameObject in SceneTree.GetGameObjects(new[] { typeof(Transform2D), typeof(CollisionArea) })) {
			
		}
	}
}