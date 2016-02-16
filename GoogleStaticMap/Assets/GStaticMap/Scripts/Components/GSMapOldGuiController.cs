/*
 * Copyright (c) 2016 Nedeljko Pejasinovic (nedjaunity@gmail.com)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

/// <summary>
/// Map controller with Unity old gui elements
/// </summary>
public class GSMapOldGuiController : MonoBehaviour {

    public GSMapRendererController mapPlane;

    private int _zoom;

    /* map type combo box */
    private GUIContent[] comboBoxList;
    private ComboBox comboBoxControl;// = new ComboBox();
    private GUIStyle listStyle = new GUIStyle();

    //detect screen resize
    private int _prevWidth;
    private int _prevHeight;

    // Use this for initialization
    void Start () {

	    if(mapPlane == null)  {
            //user not set map object
            Debug.LogError("GSMap: gui old: map not target");
        }

        comboBoxList = new GUIContent[2];
        comboBoxList[0] = new GUIContent("Satllite");
        comboBoxList[1] = new GUIContent("Hybrid");


        listStyle.normal.textColor = Color.white;
        listStyle.onHover.background =
        listStyle.hover.background = new Texture2D(2, 2);
        listStyle.padding.left =
        listStyle.padding.right =
        listStyle.padding.top =
        listStyle.padding.bottom = 4;

        comboBoxControl = new ComboBox(new Rect(Screen.width - 100, Screen.height - 250, 100, 50), comboBoxList[0], comboBoxList, "button", "box", listStyle);
    }

    void Update () {
	    if(_prevWidth != Screen.width || _prevHeight != Screen.height) {
            //screen resize
            _prevWidth = Screen.width;
            _prevHeight = Screen.height;
            comboBoxControl = new ComboBox(new Rect(Screen.width - 100, Screen.height - 250, 100, 50), comboBoxList[0], comboBoxList, "button", "box", listStyle);
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

    #region DRAW_FUNCTIONS
    bool drawCoordinateControllers()
    {
        bool changed = false;

        string newCoordLatitude = GUI.TextField(new Rect(Screen.width - 300, Screen.height - 50, 150, 50), mapPlane.coordinate.x.ToString());
        string newCoordLongitude = GUI.TextField(new Rect(Screen.width - 150, Screen.height - 100, 150, 50), mapPlane.coordinate.y.ToString());
      
        float cooLat = float.Parse(newCoordLatitude);
        float cooLon = float.Parse(newCoordLongitude);

        // check is it changed
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

        _zoom = (int)GUI.VerticalSlider(new Rect(Screen.width - 50, Screen.height - 650, 50, 300), _zoom, 17, 0);

        if(_zoom != mapPlane.zoom) {
            changed = true;
            mapPlane.zoom = (int)_zoom;
        }

        return changed;
    }

    bool drawTypeControllers()
    {
        bool changed = false;
        
        int selectedItemIndex = comboBoxControl.Show();
        GUI.Label(new Rect(Screen.width - 100, Screen.height - 280, 100, 50), comboBoxList[selectedItemIndex].text);

        if(selectedItemIndex == 0 && mapPlane.type != GSMap.GSMapType.Satellite) {
            changed = true;
            mapPlane.type = GSMap.GSMapType.Satellite;
        }
        else if (selectedItemIndex == 1 && mapPlane.type != GSMap.GSMapType.Hybrid) {
            changed = true;
            mapPlane.type = GSMap.GSMapType.Hybrid;
        }

        return changed;
    }
    #endregion DRAW_FUNCTIONS
}
