using RaylibTimelineRenderingPrototype.DrawableObject;
using RaylibTimelineRenderingPrototype.TimeEasing;

namespace RaylibTimelineRenderingPrototype.Commands;

public class FadeCommand(
    Drawable parentDrawable,
    int startTime,
    int endTime,
    float startOpacity,
    float endOpacity,
    Easing easing)
    : Command
{
    public override Drawable ParentDrawable { get; init; } = parentDrawable;

    public float StartOpacity { get; init; } = startOpacity;
    public float EndOpacity { get; init; } = endOpacity;
    
    public override int StartTime { get; init; } = startTime;
    public override int EndTime { get; init; } = endTime;

    public override Easing Easing { get; init; } = easing;

    public override void Execute(int time)
    {
        if (time < StartTime || time > EndTime)
        {
            return;
        }

        byte value = (byte)(255 * GetValueAtTime(StartOpacity, EndOpacity, time));
        ParentDrawable.Color = ParentDrawable.Color with { A = value };
    }
}