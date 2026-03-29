using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandRaycaster : MonoBehaviour {
	public GameObject cursor;
	public float CursorMinScale, CursorMaxScale, LineDistanceModifier;

	public LineRenderer lineRenderer;

	private GameObject _cursor;
	private Vector3 _cursorInitialLocalScale;
	private HoverObject _curHoverObject, _lastHoverObject;

	private void Awake() {
		if (cursor) {
			_cursor = GameObject.Instantiate(cursor);
			_cursor.transform.SetParent(transform);
			_cursorInitialLocalScale = transform.localScale;
		}
		if (lineRenderer == null) {
			lineRenderer = GetComponent<LineRenderer>();
		}
	}

	private void FixedUpdate() {
		if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100f)) {
			var hover = hit.collider.GetComponent<HoverObject>();
			if (hover != null) {
				Show(hit);
				if (hover != _curHoverObject) {
					if (_curHoverObject)
						_curHoverObject.OnUnHover();
					_curHoverObject = hover;
					_curHoverObject.OnHover();
				}
			} else {
				if (_curHoverObject) {
					_curHoverObject.OnUnHover();
					_curHoverObject = null;
				}
				Hide();
			}
		} else {
			if (_curHoverObject) {
				_curHoverObject.OnUnHover();
				_curHoverObject = null;
			}
			Hide();
		}
	}

	public void Show(RaycastHit hit) {
		float distance = Vector3.Distance(transform.position, hit.point);
		_cursor.transform.localPosition = new Vector3(0, 0, distance - 0.0001f);
		_cursor.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);

		// Scale cursor based on distance from main camera
		float cameraDist = Vector3.Distance(Camera.main.transform.position, _cursor.transform.position);
		_cursor.transform.localScale = _cursorInitialLocalScale * Mathf.Clamp(cameraDist, CursorMinScale, CursorMaxScale);

		_cursor.SetActive(true);
		if (lineRenderer) {
			lineRenderer.useWorldSpace = false;
			lineRenderer.SetPosition(0, Vector3.zero);
			lineRenderer.SetPosition(1, new Vector3(0, 0, Vector3.Distance(transform.position, hit.point) * LineDistanceModifier));
			lineRenderer.enabled = true;
		}
	}

	public void Hide() {
		_cursor.SetActive(false);
		lineRenderer.enabled = false;
	}
}
