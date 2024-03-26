using System.Numerics;
using RaylibTimelineRenderingPrototype.DrawableObject;
using RaylibTimelineRenderingPrototype.TimeEasing;

namespace RaylibTimelineRenderingPrototype.Commands;

public class MoveCommand(
    Drawable parentDrawable,
    int startTime,
    int endTime,
    Vector2 startPosition,
    Vector2 endPosition,
    Easing easing)
    : Command
{
    public override Drawable ParentDrawable { get; init; } = parentDrawable;
    
    public override int StartTime { get; init; } = startTime;
    public override int EndTime { get; init; } = endTime;

    public Vector2 StartPosition { get; init; } = startPosition;
    public Vector2 EndPosition { get; init; } = endPosition;

    public override Easing Easing { get; init; } = easing;
    
    public override void Execute(int time)
    {
        if (time < StartTime || time > EndTime)
        {
            return;
        }
        
        ParentDrawable.DrawAction(GetPositionAtTime(time), ParentDrawable.Color);
    }
    
    private Vector2 GetPositionAtTime(int time)
    {
        return new Vector2(
            GetValueAtTime(StartPosition.X, EndPosition.X, time),
            GetValueAtTime(StartPosition.Y, EndPosition.Y, time)
        );
    }
}