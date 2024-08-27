using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtension
{
    public static string toForematString(this float value, int pointNum = 0)
    {
        if (pointNum == 0) return string.Format("{0:N0}", value);
        else if (pointNum == 1) return string.Format("{0:N1}", value);
        else if (pointNum == 2) return string.Format("{0:N2}", value);
        else if (pointNum == 3) return string.Format("{0:N3}", value);
        else return value.ToString();
    }

    public static string toPersentString(this  float value)
    {
        return (value * 100).toForematString() + "%";
    }
}
