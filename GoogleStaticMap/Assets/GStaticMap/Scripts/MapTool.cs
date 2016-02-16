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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GSMap
{
    /// <summary>
    /// Tools
    /// </summary>
    public class GSMapTool
    {
        /// <summary>
        /// 
        /// </summary>
        public static string GoogleStaticMapUrlBase = "http://maps.google.com/maps/api/staticmap?";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public static string MakeUrlRequest(GSIMap map)
        {
            return MakeUrlRequest(map.Size, map.Coordinate,
                                   map.Zoom, map.Type,
                                   map.Markers,
                                   map.DeveloperKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="coordinate"></param>
        /// <param name="zoom"></param>
        /// <param name="type"></param>
        /// <param name="markers"></param>
        /// <returns></returns>
        public static string MakeUrlRequest(Vector2 size,
                                            Vector2 coordinate,
                                            int zoom,
                                            GSMapType type,
                                            IMarker[] markers,
                                            string key = "")
        {
            string ret = GoogleStaticMapUrlBase                                          // request base string adress
            + "center=" + coordinate[1].ToString() + "," + coordinate[0].ToString() // + position
            + "&zoom=" + zoom.ToString()                              // + zoom
            + "&size=" + size[0].ToString() + "x" + size[1].ToString()// + size
            + "&maptype=" + type.ToString().ToLower();        // + maptype
                                                              // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[0].ToString() + "," + coo[1].ToString() // + marker example
                                                              // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[1].ToString() + "," + coo[1].ToString();// + marker example


            foreach (IMarker marker in markers)
            {
                ret += "&markers=%7Clabel:1%7C" + marker.latitude.ToString() + "," + marker.longitude.ToString();
            }


            /* google static map api key */
            if(key.Length > 0) {
                ret += "&key=" + key;
            }

            return ret;
        }

    }
}
