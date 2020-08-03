using UnityEngine;

namespace RewindEngine.Example
{
	// A base class that provides a shortcut 
	// for accessing the timeline component.
	[RequireComponent(typeof(Timeline))]
	public abstract class ExampleBaseBehaviour : MonoBehaviour
	{
		public Timeline time
		{
			get { return GetComponent<Timeline>(); }
		}
	}
}
