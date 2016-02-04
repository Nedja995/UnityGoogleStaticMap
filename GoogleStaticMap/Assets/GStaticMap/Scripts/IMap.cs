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
    /// 
    /// </summary>
    public interface GSIMap
    {
        /// <summary>
        /// 
        /// </summary>
        Vector2 Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Vector2 Coordinate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int Zoom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Vector2[] Markers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        GSMapType Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Key { get; set; }
    }

}


