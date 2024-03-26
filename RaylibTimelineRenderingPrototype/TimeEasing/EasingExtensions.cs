using static RaylibTimelineRenderingPrototype.TimeEasing.EasingFunctions;

namespace RaylibTimelineRenderingPrototype.TimeEasing;

public static class EasingExtensions
{
    public static double Ease(this Easing easing, double time)
    {
        return easing switch
        {
            Easing.InCubic => InCubic(time),
            Easing.OutCubic => OutCubic(time),
            _ => time
        };
    }
}