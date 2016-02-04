using UnityEngine;
using System.Collections;
using System;

using GSMap;

/// <summary>
/// 
/// </summary>
public class GSMapPlaneController : MonoBehaviour
{
    [Header("Map data")]
    public Vector2 size;
    public Vector2 coordinate;
    public int zoom;
    public UIMarker[] markers;
    public GSMapType type;

    [Header("Developer")]
    public string key;

    [Header("Plane")]
    public bool refresh;

    #region PrivateMembers
    private Renderer _renderer;
    private GSMapComponent _mapCmp;
    #endregion

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (!_renderer) {
            Debug.LogError("GSMap: PlaneController: missing renderer");
        }

        _mapCmp = GetComponent<GSMapComponent>();
        if (!_mapCmp) {
            Debug.LogError("GSMap: PlaneController: missing map MapComponent");
        }
    }


    void Update()
    {
        if (refresh)
        {
            refresh = false;
            Refresh();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Refresh()
    {
        _mapCmp.Size = size;
        _mapCmp.Zoom = zoom;
        _mapCmp.Coordinate = coordinate;
        _mapCmp.Type = type;
        _mapCmp.Key = key;
        _mapCmp.Markers = markers;
        _mapCmp.Load((Texture2D tex) =>
        {
            _renderer.material.mainTexture = tex;
        });
    }

}

