using System.Numerics;

namespace RaylibTimelineRenderingPrototype;

public record Point(Vector2 Position, double Time)
{
    public float X => Position.X;
    public float Y => Position.Y;
}