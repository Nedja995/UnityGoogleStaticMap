
using GSMap;
using System;

[System.Serializable]
public class UIMarker : IMarker
{
    public float Latitude;
    public float Longitude;

    public float latitude
    {
        get { return Latitude; }
        set { Latitude = value; }
    }

    public float longitude
    {
        get { return Longitude; }
        set { Longitude = value; }
    }
}

