using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler
{

	public GameObject obama, displayPane, displayPane2;

	void Start ()
	{
		// Search for all Children from this ImageTarget with type VirtualButtonBehaviour
		VirtualButtonBehaviour [] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
		for (int i = 0; i < vbs.Length; ++i)
		{
			// Register with the virtual buttons TrackableBehaviour
			vbs [i].RegisterEventHandler (this);
		}
		displayPane.SetActive (false);
		displayPane2.SetActive (false);
		obama.SetActive (true);
	}

	public void OnButtonPressed (VirtualButtonBehaviour vb)
	{
		switch (vb.VirtualButtonName)
		{
			case "About":
				displayPane.SetActive (false);
				displayPane2.SetActive (true);
				obama.SetActive (false);
				break;
			case "Video":
				displayPane.SetActive (true);
				displayPane2.SetActive (false);
				obama.SetActive (false);
				break;
			default:
				throw new UnityException ("Button not supported: " + vb.VirtualButtonName);
				break;
		}
	}

	public void OnButtonReleased (VirtualButtonBehaviour vb)
	{
		Debug.Log ("VB Released");
	}
}