using UnityEngine;

namespace SKUtils.Interaction
{
	public class Door : Iinteractable
	{
		[SerializeField] string _interactionPrompt;
		public string InteractionPrompt => _interactionPrompt;

		[SerializeField] KeyCode _interactionKeyCode;	
		public KeyCode InteractionKeyCode => _interactionKeyCode;

		public void Interact(GameObject go)
		{
        // //do stuff...
		}
	}
}
