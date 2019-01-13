using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Connection {

	public ConnectionPoint inPoint;
	public ConnectionPoint outPoint;
	public Action<Connection> OnClickRemoveConnection;

	public Connection(ConnectionPoint inPoint, ConnectionPoint outPoint, Action<Connection> OnClickRemoveConnection) {
		this.inPoint = inPoint;
		this.outPoint = outPoint;
		this.OnClickRemoveConnection = OnClickRemoveConnection;
	}

	public void Draw() {
		Handles.DrawBezier(
			inPoint.rect.center,
			outPoint.rect.center,
			inPoint.rect.center + Vector2.left * 50f,
			outPoint.rect.center - Vector2.left * 50f,
			Color.white,
			null,
			2f
		);

		Handles.RectangleHandleCap(0, Vector3.zero, Quaternion.identity, 1f, EventType.Repaint);

		if (Handles.Button((inPoint.rect.center + outPoint.rect.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleHandleCap)) {
			if (OnClickRemoveConnection != null) {
				OnClickRemoveConnection(this);
			}
		}
	}
}