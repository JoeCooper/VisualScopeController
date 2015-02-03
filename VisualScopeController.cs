using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Camera))]
public class VisualScopeController : MonoBehaviour {

	private new Camera camera;
	private new Transform transform;

	public float minimumAngle = 20, maximumAngle = 90;
	public float smoothTime = 0.5f;
	public float margin = 1.1f;

	private float angleRateOfChange = 0f;

	void Update () {
		camera = camera ?? gameObject.GetComponent<Camera>();
		transform = transform ?? gameObject.GetComponent<Transform>();

		var idealAngle = (minimumAngle + maximumAngle) / 2f;

		var filters = gameObject.GetComponents<AbstractVisualScopeFilter>();

		var allTargets = new List<Transform>();

		foreach(var filter in filters)
		{
			allTargets.AddRange(filter.Targets);
		}

		if(allTargets.Count > 0)
		{
			var positions = new Vector3[allTargets.Count];

			for(int i = 0; i < allTargets.Count; i++)
			{
				positions[i] = allTargets[i].position;
			}
			
			var matrix = transform.worldToLocalMatrix;
			
			for(int i = 0; i < positions.Length; i++)
			{
				positions[i] = matrix.MultiplyPoint3x4(positions[i]);
			}

			var greatestAngle = float.MinValue;

			var fieldOfView = camera.fieldOfView * Mathf.Deg2Rad;
			var horizontalFieldOfView = 2f * Mathf.Atan(Mathf.Tan(fieldOfView / 2f) * camera.aspect);
			var horizontalRelation = fieldOfView / horizontalFieldOfView;

			foreach(var position in positions)
			{
				if(position.z < camera.nearClipPlane)
					continue;

				var zSquare = position.z * position.z;
				var alfaD = Mathf.Sqrt(position.x * position.x + zSquare);
				var bravoD = Mathf.Sqrt(position.y * position.y + zSquare);

				var alfa = Mathf.Asin(Mathf.Abs(position.x / alfaD)) * horizontalRelation;
				var bravo = Mathf.Asin(Mathf.Abs(position.y / bravoD));

				greatestAngle = alfa > greatestAngle ? alfa : greatestAngle;
				greatestAngle = bravo > greatestAngle ? bravo : greatestAngle;
			}
						
			idealAngle = Mathf.Clamp(greatestAngle * Mathf.Rad2Deg * 2f * margin, minimumAngle, maximumAngle);
		}

		camera.fieldOfView = Mathf.SmoothDamp(camera.fieldOfView, idealAngle, ref angleRateOfChange, smoothTime);
	}
}
