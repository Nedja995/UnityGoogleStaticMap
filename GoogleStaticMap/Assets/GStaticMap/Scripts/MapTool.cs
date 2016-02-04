using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GSMap
{
    /// <summary>
    /// 
    /// </summary>
    public class GSMapTool
    {
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
                                   map.Key);
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
                                            ArrayList markers,
                                            string key = "")
        {
            string ret = GoogleStaticMapUrlBase                                          // request base string adress
            + "center=" + coordinate[1].ToString() + "," + coordinate[0].ToString() // + position
            + "&zoom=" + zoom.ToString()                              // + zoom
            + "&size=" + size[0].ToString() + "x" + size[1].ToString()// + size
            + "&maptype=" + type.ToString().ToLower();                          // + maptype
                                                              // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[0].ToString() + "," + coo[1].ToString() // + marker example
                                                              // + "&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7C" + coo[1].ToString() + "," + coo[1].ToString();// + marker example

            /* google static map api key */
            if(key.Length > 0) {
                ret += "&key=" + key;
            }

            return ret;
        }

    }
}
