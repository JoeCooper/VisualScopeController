using UnityEngine;
using System.Collections.Generic;

public class BasicVisualScopeFilter : AbstractVisualScopeFilter {

	private static readonly IEnumerable<Transform> EmptySet = new Transform[0];

	public Transform[] targets;

	#region implemented abstract members of AbstractVisualScopeFilter

	public override IEnumerable<Transform> Targets {
		get {
			return targets ?? EmptySet;
		}
	}

	#endregion



}
