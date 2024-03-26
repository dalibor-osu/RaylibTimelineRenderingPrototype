using RaylibTimelineRenderingPrototype.DrawableObject;
using RaylibTimelineRenderingPrototype.TimeEasing;

namespace RaylibTimelineRenderingPrototype.Commands;

public abstract class Command
{
    public abstract Drawable ParentDrawable { get; init; }
    
    public abstract int StartTime { get; init; }
    public abstract int EndTime { get; init; }
    public abstract Easing Easing { get; init; }
    
    public abstract void Execute(int time);
    
    protected float GetValueAtTime(float startValue, float endValue, int time) =>
        startValue + (endValue - startValue) * (float) Easing.Ease(((double)(time - StartTime)) / (EndTime - StartTime));
}