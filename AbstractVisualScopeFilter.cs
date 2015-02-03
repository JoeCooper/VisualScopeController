using UnityEngine;
using System.Collections.Generic;

public abstract class AbstractVisualScopeFilter : MonoBehaviour
{
	public abstract IEnumerable<Transform> Targets { get; }
}
