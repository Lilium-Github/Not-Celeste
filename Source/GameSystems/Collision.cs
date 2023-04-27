namespace Not_Celeste.GameSystems;

internal class Collision : GameSystem {
	public override void Process(double Delta) {
		foreach (GameObject gameObject in SceneTree.GetGameObjects(new[] { typeof(Transform2D), typeof(CollisionArea) })) {
			var GlobalTransform = Transform2DUtils.GetGlobalTransform2D(gameObject);
			foreach (GameObject gameObject2 in SceneTree.GetGameObjects(new[] { typeof(Transform2D), typeof(CollisionArea) })) {
				var GlobalTransform2 = Transform2DUtils.GetGlobalTransform2D(gameObject);

				var isCollided = false;
				foreach (FloatRect collisionRect in ((CollisionArea) gameObject[typeof(CollisionArea)]).Bounds) {
					foreach (FloatRect collisionRect2 in ((CollisionArea) gameObject[typeof(CollisionArea)]).Bounds) {
						if (
							new FloatRect(
								collisionRect.Left + GlobalTransform.Position.X,
								collisionRect.Top + GlobalTransform.Position.Y,
								collisionRect.Width,
								collisionRect.Height
							).Intersects(
								new FloatRect(
									collisionRect2.Left + GlobalTransform2.Position.X,
									collisionRect2.Top + GlobalTransform2.Position.Y,
									collisionRect2.Width,
									collisionRect2.Height
								)
							)
						) isCollided = true;
					}
				}
				if (isCollided) {
					((CollisionArea) gameObject[typeof(CollisionArea)]).CollidedObjects.Add(gameObject2);
				}
			}
		}
	}
}
