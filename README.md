# VisualScopeController
A Unity3D component which manages a camera's field of view to ensure the visibility of a given set of targets.
The component is to attached to a GameObject alongside a Camera component. It will then attempt to govern that camera's field of view, in order to keep a set of targets in its view.
In order to provide a set of targets to the visual scope controller, you must attach one or more components inheriting from AbstractVisualScopeFilter.
## AbstractVisualScopeFilter
This class inherits from MonoBehaviour (ensuring that it is a component) and offers one abstract method; IEnumerable<Transform> Targets { get; }
Subclasses of AbstractVisualScopeFilter must implement Targets. The VisualScopeController will poll this method to find targets which it must encompass.
## BasicVisualScopeFilter
This example implementation of the AbstractVisualScopeFilter allows you to assign a set of objects in the Unity inspector and will provide this set to the VisualScopeController.