namespace RaylibTimelineRenderingPrototype.TimeEasing;

public static class EasingFunctions
{
    public static double OutCubic(double x) => 1 - Math.Pow(1 - x, 3);
    public static double InCubic(double x) => Math.Pow(x, 3);
}