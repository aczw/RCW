using System;

public static class Easings
{
    public static float EaseOutQuint(float num)
    {
        return (float) (1 - Math.Pow(1 - num, 5));
    }

    public static float EaseInQuint(float num)
    {
        return num * num * num * num * num;
    }
}
