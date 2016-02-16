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
using System.Collections;
using UnityEngine;

/// <summary>
/// 
/// </summary>
namespace GSMap
{
    /// <summary>
    /// 
    /// </summary>
    public enum GSMapType
    {
        Satellite,
        Hybrid
    }

    /// <summary>
    /// Abstraction of map data.
    /// Used for make URL request and store map state.
    /// It will use for implement other similar services.
    /// like <see cref="https://www.google.rs/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=google%20static%20map%20alternative"/>.
    /// </summary>
    public interface GSIMap
    {
        /// <summary>
        /// View size
        /// </summary>
        Vector2 Size { get; set; }
        /// <summary>
        /// Geographic coordinates of view center
        /// </summary>
        Vector2 Coordinate { get; set; }
        /// <summary>
        /// Map zoom
        /// </summary>
        int Zoom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IMarker[] Markers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        GSMapType Type { get; set; }
        /// <summary>
        /// Usualy need for URL request.
        /// </summary>
        string DeveloperKey { get; set; }
    }

}


