using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
  

    public static string FloatToLimitedSizeString(float f, int size)
    {
        return FloatToLimitedSizeString(f, size, "0.00");
    }

    public static string FloatToLimitedSizeString(float f, int size, string format)
    {
        return f.ToString(format, System.Globalization.CultureInfo.InvariantCulture);
    }

}
