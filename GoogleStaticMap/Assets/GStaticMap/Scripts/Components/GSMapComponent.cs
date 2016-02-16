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
using System;

using GSMap;

/// <summary>
/// Controller that comunicate with Google Static Map service.
/// </summary>
public class GSMapComponent : MonoBehaviour, GSIMap
{
    [Header("Developer")]
    public string key;

    [Header("Debug")]
    public bool printRequest;

    private Texture2D _mapTexture;
    private bool _loaded;
    private Action<Texture2D> _onLoad;

    // Execute callbacks in main thread
    void Update()
    {
        if (_loaded)
        {
            _loaded = false;
            if (_mapTexture == null || _onLoad == null)
            {
                // No data loaded
            }
            else
            {
                // Execute callback
                _onLoad(_mapTexture);
                // Reset callback
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
        // configure developer key
        DeveloperKey = key;
        _onLoad = onLoad;
        StartCoroutine(_loadImage());
    }


    private IEnumerator _loadImage()
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

    public string DeveloperKey
    {
        get;

        set;
    }
    #endregion

}
