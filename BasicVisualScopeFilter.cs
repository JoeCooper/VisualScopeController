using UnityEngine;
using System.Collections.Generic;

public class BasicVisualScopeFilter : AbstractVisualScopeFilter {

	public Transform[] targets;

	#region implemented abstract members of AbstractVisualScopeFilter

	public override IEnumerable<Transform> Targets {
		get {
			return targets;
		}
	}

	#endregion



}
