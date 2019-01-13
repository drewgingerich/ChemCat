﻿using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class EventGraph : EditorWindow {

	private List<EventNode> nodes;
	private List<Connection> connections;

	private GUIStyle nodeStyle;
	private GUIStyle selectedNodeStyle;
	private GUIStyle inPointStyle;
	private GUIStyle outPointStyle;

	private ConnectionPoint selectedInPoint;
	private ConnectionPoint selectedOutPoint;

	[MenuItem("Window/Event Graph")]
	public static void ShowWindow() {
		EditorWindow.GetWindow(typeof(EventGraph));
	}

	private void OnEnable() {
		nodeStyle = new GUIStyle();
		nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
		nodeStyle.border = new RectOffset(12, 12, 12, 12);

		selectedNodeStyle = new GUIStyle();
		selectedNodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1 on.png") as Texture2D;
		selectedNodeStyle.border = new RectOffset(12, 12, 12, 12);

		inPointStyle = new GUIStyle();
		inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
		inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
		inPointStyle.border = new RectOffset(4, 4, 12, 12);

		outPointStyle = new GUIStyle();
		outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
		outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
		outPointStyle.border = new RectOffset(4, 4, 12, 12);
	}

	private void OnGUI() {
		DrawNodes();
		DrawConnections();

		ProcessNodeEvents(Event.current);
		ProcessEvents(Event.current);
		if (GUI.changed)
			Repaint();
	}

	private void DrawNodes() {
		if (nodes != null) {
			foreach (EventNode node in nodes) {
				node.Draw();
			}
		}
	}

	private void DrawConnections() {
		if (connections != null) {
			for (int i = 0; i < connections.Count; i++) {
				connections[i].Draw();
			}
		}
	}

	private void ProcessEvents(Event e) {
		switch(e.type) {
			case EventType.MouseDown:
				if (e.button == 1) {
					ProcessContextMenu(e.mousePosition);
				}
				break;
		}
	}

	private void ProcessNodeEvents(Event e) {
		if (nodes == null)
			return;
		foreach (EventNode node in nodes) {
			bool guiChanged = node.ProcessEvents(e);
			if (guiChanged) {
				GUI.changed = true;
			}
		}
	}

	private void ProcessContextMenu(Vector2 mousePosition) {
		GenericMenu genericMenu = new GenericMenu();
		genericMenu.AddItem(new GUIContent("Add node"), false, () => OnClickAddNode(mousePosition));
		genericMenu.ShowAsContext();
	}

	private void OnClickAddNode(Vector2 mousePosition) {
		if (nodes == null)
			nodes = new List<EventNode>();
		nodes.Add(new EventNode(mousePosition, 200, 50, nodeStyle, selectedNodeStyle, inPointStyle, outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode));
	}

	private void OnClickInPoint(ConnectionPoint inPoint) {
		selectedInPoint = inPoint;
		if (selectedOutPoint != null) {
			if (selectedOutPoint.node != selectedInPoint.node) {
				CreateConnection();
				ClearConnectionSelection();
			} else {
				ClearConnectionSelection();
			}
		}
	}

	private void OnClickOutPoint(ConnectionPoint outPoint) {
		selectedOutPoint = outPoint;
		if (selectedInPoint != null) {
			if (selectedOutPoint.node != selectedInPoint.node) {
				CreateConnection();
				ClearConnectionSelection();
			} else {
				ClearConnectionSelection();
			}
		}
	}

	private void OnClickRemoveConnection(Connection connection) {
		connections.Remove(connection);
	}

	private void CreateConnection() {
		if (connections == null) {
			connections = new List<Connection>();
		}
		connections.Add(new Connection(selectedInPoint, selectedOutPoint, OnClickRemoveConnection));
	}

	private void ClearConnectionSelection() {
		selectedInPoint = null;
		selectedOutPoint = null;
	}
	private void OnClickRemoveNode(EventNode node) {
		if (connections != null) {
			List<Connection> connectionsToRemove = new List<Connection>();

			for (int i = 0; i < connections.Count; i++) {
				if (connections[i].inPoint == node.inPoint || connections[i].outPoint == node.outPoint) {
					connectionsToRemove.Add(connections[i]);
				}
			}

			for (int i = 0; i < connectionsToRemove.Count; i++) {
				connections.Remove(connectionsToRemove[i]);
			}
			connectionsToRemove = null;
		}

		nodes.Remove(node);
	}
}
