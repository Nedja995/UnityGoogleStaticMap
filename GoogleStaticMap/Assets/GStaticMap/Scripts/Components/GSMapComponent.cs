using UnityEngine;
using System.Collections;
using System;

using GSMap;

/// <summary>
/// 
/// </summary>
public class GSMapComponent : MonoBehaviour, GSIMap
{
    [Header("Debug")]
    public bool printRequest;

    private Texture2D _mapTexture;
    private bool _loaded;
    private Action<Texture2D> _onLoad;

    void Start()
    {

    }

    void Update()
    {
        if (_loaded)
        {
            _loaded = false;
            if (_mapTexture == null || _onLoad == null)
            {
                Debug.Log("GSMap: MapComponent: failed load data");
            }
            else
            {
                _onLoad(_mapTexture);
                _onLoad = null;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="onLoad"></param>
    public void Load(Action<Texture2D> onLoad)
    {
        _onLoad = onLoad;
        StartCoroutine(_reloadImage());
    }


    private IEnumerator _reloadImage()
    {
        //make url
        string reqUrl = GSMapTool.MakeUrlRequest(this);
        //debug request
        if (printRequest) {
            Debug.Log("GSMap: request: " + reqUrl);
        }

        //request
        WWW www = new WWW(reqUrl);

        //wait
        yield return www;

        //set buffer
        _mapTexture = www.texture;
        //callback flag
        _loaded = true;
    }


    #region INTERFACE
    public Vector2 Coordinate
    {
        get;

        set;
    }

    public IMarker[] Markers
    {
        get;

        set;
    }

    public Vector2 Size
    {
        get;

        set;
    }

    public GSMapType Type
    {
        get;

        set;
    }

    public int Zoom
    {
        get;

        set;
    }

    public string Key
    {
        get;

        set;
    }
    #endregion

}
