using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class GSMapOldGuiController : MonoBehaviour {

    public GSMapPlaneController mapPlane;

	// Use this for initialization
	void Start () {

	    if(mapPlane == null)  {
            //user not set map object
            Debug.LogError("GSMap: gui old: map not target");
        }
	}

    void OnGUI()
    {
        bool refreshMap = false;

        if (drawCoordinateControllers()) {
            refreshMap = true;
        }

        if (drawZoomControllers())  {
            refreshMap = true;
        }

        if (drawTypeControllers()) {
            refreshMap = true;
        }

        //draw refresh btn
        if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 50, 150, 50), "Refresh"))
        {
            refreshMap = true;
        }

        if (refreshMap){
            mapPlane.Refresh();
        }
           
    }

    bool drawCoordinateControllers()
    {
        bool changed = false;
        string newCoordLatitude = GUI.TextField(new Rect(Screen.width - 300, Screen.height - 50, 150, 50), mapPlane.coordinate.x.ToString());
        string newCoordLongitude = GUI.TextField(new Rect(Screen.width - 150, Screen.height - 100, 150, 50), mapPlane.coordinate.y.ToString());

        float cooLat = float.Parse(newCoordLatitude);
        float cooLon = float.Parse(newCoordLongitude);

        if(cooLat != mapPlane.coordinate.x)  {
            mapPlane.coordinate.x = cooLat;
            changed = true;
        }

        if(cooLon != mapPlane.coordinate.y)  {
            mapPlane.coordinate.y = cooLon;
            changed = true;
        }

        /* up */
        if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 160, 150, 30), "Up")) {
            changed = true;
            mapPlane.coordinate.y += 5.0f;
        }
        /* down */
        if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 130, 150, 30), "Down"))  {
            changed = true;
            mapPlane.coordinate.y -= 5.0f;
        }
        /* right */
        if (GUI.Button(new Rect(Screen.width - 375, Screen.height - 50, 75, 50), "Right")) {
            changed = true;
            mapPlane.coordinate.x += 5.0f;
        }
        /* left */
        if (GUI.Button(new Rect(Screen.width - 450, Screen.height - 50, 75, 50), "Left"))  {
            changed = true;
            mapPlane.coordinate.x -= 5.0f;
        }
        return changed;
    }

    bool drawZoomControllers()
    {
        bool changed = false;
        return changed;
    }

    bool drawTypeControllers()
    {
        bool changed = false;
        return changed;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
