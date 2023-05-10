namespace Not_Celeste.Utils;

internal abstract class CollisionShape {
	/// <summary>
	/// gets the polygonal definitition of the collision object (counterclockwise)
	/// 
	/// </summary>
	/// <returns></returns>
	public abstract List<Vector2f> getPolygon();

	// public bool collide(CollisionShape target) {

	// }
	
	public Tuple<double, Line>? ProjectionCollide(CollisionShape target, Vector2f Velocity)
	{
		var poly1 = getPolygon();
		var poly2 = target.getPolygon();

		var lines1 = new List<Line>(poly1.Count);
		var lines2 = new List<Line>(poly2.Count);

		for (var i = 0; i < poly1.Count; i++) {
			lines1.Add(new(poly1[i], poly1[i + 1 % poly1.Count]));
		}

		for (var i = 0; i < poly2.Count; i++) {
			lines2.Add(new(poly2[i], poly2[i + 1 % poly2.Count]));
		}

		var collisions = new List<Tuple<double, Tuple<Vector2f, Vector2f>>>();

		foreach (var point in poly1) {
			foreach (var line in lines2) {
				// collide the line made by (point, point + Velocity) with line
				
				

			}
		}
	}
}