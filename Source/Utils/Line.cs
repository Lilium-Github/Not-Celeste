namespace Not_Celeste.Utils;

internal struct Line {
	public Vector2f StartPoint;
	public Vector2f EndPoint;

	public Line(Vector2f startPoint, Vector2f endPoint) {
		StartPoint = startPoint;
		EndPoint = endPoint;
	}

	public Vector2f? Collide(Line target) {
		var mySlope = (EndPoint.Y - StartPoint.Y) / ((EndPoint.X - StartPoint.X));
		var targetSlope = (target.EndPoint.Y - target.StartPoint.Y) / ((target.EndPoint.X - target.StartPoint.X));

		if (!float.IsRealNumber(mySlope) && !float.IsRealNumber(targetSlope)) return null;

		float myYIntercept;
		float targetYIntercept;

		float collideX;
		float collideY;
		
		if (!float.IsRealNumber(mySlope)) {
			targetYIntercept = target.StartPoint.Y - (target.StartPoint.X * targetSlope);

			collideX = StartPoint.X;
			collideY = targetSlope * collideX + targetYIntercept;
		} else if (!float.IsRealNumber(targetSlope)) {
			myYIntercept = StartPoint.Y - (StartPoint.X * mySlope);

			collideX = target.StartPoint.X;
			collideY = mySlope * collideX + myYIntercept;
		} else if (mySlope == targetSlope) {
			return null;
		} else {
			myYIntercept = StartPoint.Y - (StartPoint.X * mySlope);
			targetYIntercept = target.StartPoint.Y - (target.StartPoint.X * targetSlope);

			collideX = (myYIntercept - targetYIntercept) / (targetSlope - mySlope);
			collideY = mySlope * collideX + myYIntercept;
		}

		if (StartPoint.X > EndPoint.X) {
			if (collideX < StartPoint.X && collideX > EndPoint.X) return null;
		} else if (collideX > StartPoint.X && collideX < EndPoint.X) return null;
		
		if (target.StartPoint.X > target.EndPoint.X) {
			if (collideX < target.StartPoint.X && collideX > target.EndPoint.X) return null;
		} else if (collideX > target.StartPoint.X && collideX < target.EndPoint.X) return null;

		return new(collideX, collideY);
	}
}
