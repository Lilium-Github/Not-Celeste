namespace Not_Celeste.Utils;

internal abstract class CollisionShape {
	/// <summary>
	/// gets the polygonal definitition of the collision object (counterclockwise)
	/// 
	/// </summary>
	/// <returns></returns>
	public abstract List<Vector2f> GetPolygon();

	// public bool collide(CollisionShape target) {

	// }
	
	public Tuple<double, Line>? ProjectionCollide(CollisionShape target, Vector2f velocity)
	{
		var poly1 = GetPolygon();
		var poly2 = target.GetPolygon();

		var lines1 = new List<Line>(poly1.Count);
		var lines2 = new List<Line>(poly2.Count);

		for (var i = 0; i < poly1.Count; i++) {
			lines1.Add(new(poly1[i], poly1[i + 1 % poly1.Count]));
		}

		for (var i = 0; i < poly2.Count; i++) {
			lines2.Add(new(poly2[i], poly2[i + 1 % poly2.Count]));
		}

		var collisions = new List<Tuple<double, Line>>();

		foreach (var point in poly1) {
			foreach (var line in lines2) {
				var collidePoint = new Line(point, point + velocity).Collide(line);

				if (collidePoint != null) {
					var distanceVector = (Vector2f) collidePoint - point;

					var distanceSquared = Math.Pow(distanceVector.X, 2) + Math.Pow(distanceVector.Y, 2);

					collisions.Add(new(distanceSquared, line));
				}
			}
		}

		foreach (var point in poly2) {
			foreach (var line in lines1) {
				var collidePoint = new Line(point, point - velocity).Collide(line);

				if (collidePoint != null) {
					var distanceVector = (Vector2f) collidePoint - point;

					var distanceSquared = Math.Pow(distanceVector.X, 2) + Math.Pow(distanceVector.Y, 2);

					collisions.Add(new(distanceSquared, line));
				}
			}
		}


		return null;
	}
}