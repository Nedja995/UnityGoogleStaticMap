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
/// 
/// </summary>
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(GSMapComponent))]
public class GSMapRendererController : MonoBehaviour
{
    [Header("Map data")]
    public Vector2 size;
    public Vector2 coordinate;
    public int zoom;
    public UIMarker[] markers;
    public GSMapType type;



    [Header("Texture")]
    public bool refresh;

    #region PrivateMembers
    private Renderer _renderer;
    private GSMapComponent _mapCmp;
    #endregion

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (!_renderer) {
            Debug.LogError("GSMap: MaterialController: missing renderer");
        }

        _mapCmp = GetComponent<GSMapComponent>();
        if (!_mapCmp) {
            Debug.LogError("GSMap: MaterialController: missing map MapComponent");
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
    /// Refresh main texture
    /// </summary>
    public void Refresh()
    {
        // configure map for request
        _mapCmp.Size = size;
        _mapCmp.Zoom = zoom;
        _mapCmp.Coordinate = coordinate;
        _mapCmp.Type = type;     
        _mapCmp.Markers = markers;
        // send request and callback
        _mapCmp.Load((Texture2D tex) =>
        {
            _renderer.material.mainTexture = tex;
        });
    }

}

