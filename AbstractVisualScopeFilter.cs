using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(VisualScopeController))]
public abstract class AbstractVisualScopeFilter : MonoBehaviour
{
	public abstract IEnumerable<Transform> Targets { get; }
}
