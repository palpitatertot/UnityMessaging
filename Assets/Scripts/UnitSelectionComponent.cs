using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class UnitSelectionComponent : MonoBehaviour
{
	bool isSelecting = false;
	Bounds zeroBounds; 
	Bounds selectedBounds;
	Vector3 mousePosition1;
	Camera camera;
	void Start(){
		zeroBounds = new Bounds(Vector3.zero, Vector3.zero);
		selectedBounds = zeroBounds;
		camera = Camera.main;
	}
	void Update()
	{
		// If we press the left mouse button, save mouse location and begin selection
		if (Input.GetMouseButtonDown (0)) {
			isSelecting = true;
			mousePosition1 = Input.mousePosition;
			//selectedBounds =
			//Utils.GetViewportBounds( camera, mousePosition1, Input.mousePosition );
		}
		// If we let go of the left mouse button, end selection
		if (Input.GetMouseButtonUp (0)) {
			selectedBounds =
				Utils.GetViewportBounds( camera, mousePosition1, Input.mousePosition );
			isSelecting = false;
		}
	}
	void OnGUI()
	{
		if( isSelecting )
		{
			// Create a rect from both mouse positions
			var rect = Utils.GetScreenRect( mousePosition1, Input.mousePosition );
			Utils.DrawScreenRect( rect, new Color( 0.8f, 0.8f, 0.95f, 0.25f ) );
			Utils.DrawScreenRectBorder( rect, 2, new Color( 0.8f, 0.8f, 0.95f ) );
		}
	}

	public bool IsWithinSelectionBounds( GameObject gameObject )
	{
		if( selectedBounds == zeroBounds )
			return false;

		if (isSelecting) {
			selectedBounds =
			Utils.GetViewportBounds( camera, mousePosition1, Input.mousePosition );

			return selectedBounds.Contains(
				camera.WorldToViewportPoint( gameObject.transform.position ) );
		}

		if (!isSelecting) {
			return selectedBounds.Contains(
				camera.WorldToViewportPoint( gameObject.transform.position ) );
			
		}

		return false;
		//return selectedBounds.Contains(
			//camera.WorldToViewportPoint( gameObject.transform.position ) );
	}
}



