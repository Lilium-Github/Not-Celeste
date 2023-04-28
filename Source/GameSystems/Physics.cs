namespace Not_Celeste.GameSystems;

internal class Physics : GameSystem {
	public override void Process(double delta) {
		//
	}
	public Transform2D GetPredictedGlobalTransform2D(GameObject target, float delta) {
		if (System.Object.ReferenceEquals(target, SceneTree.SceneRoot)) {
			if (target.Components.ContainsKey(typeof(PhysicsProperties))) {
				var physicsProperties = (PhysicsProperties) target[typeof(PhysicsProperties)];
				var result = ((Transform2D) target[typeof(Transform2D)]).Copy();

				result.Position += (physicsProperties.Velocity + (((physicsProperties.Force / physicsProperties.Mass) * delta) + (physicsProperties.Impulse / physicsProperties.Mass))) * delta;

				return result;
			} else if (target.Components.ContainsKey(typeof(Transform2D))) {
				return ((Transform2D) target[typeof(Transform2D)]).Copy();
			} else return new Transform2D() {Position = new(0, 0)};
		} else if (target.Parent != null) {
			if (target.Components.ContainsKey(typeof(PhysicsProperties))) {
				var physicsProperties = (PhysicsProperties) target[typeof(PhysicsProperties)];
				var result = ((Transform2D) target[typeof(Transform2D)]).Copy();

				result.Position += (physicsProperties.Velocity + (((physicsProperties.Force / physicsProperties.Mass) * delta) + (physicsProperties.Impulse / physicsProperties.Mass))) * delta;

				return result + GetPredictedGlobalTransform2D(target.Parent, delta);
			} else if (target.Components.ContainsKey(typeof(Transform2D))) {
				return ((Transform2D) target[typeof(Transform2D)]) + GetPredictedGlobalTransform2D(target.Parent, delta);
			} else return GetPredictedGlobalTransform2D(target.Parent, delta);
		} else {
			throw new ArgumentException("Attemted to get the predicted global transform of something in a disconnected tree!");
		}
	}
}