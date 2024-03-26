using System.Numerics;
using Raylib_cs;
using RaylibTimelineRenderingPrototype.Commands;
using RaylibTimelineRenderingPrototype.TimeEasing;

namespace RaylibTimelineRenderingPrototype.DrawableObject;

public class Drawable(Action<Vector2, Color> drawAction)
{
    private readonly List<Command> _commandList = [];
    
    public Color Color { get; set; } = Color.Black;
    
    public Action<Vector2, Color> DrawAction { get; init; } = drawAction;

    public List<Command> GetCommandList()
    {
        return _commandList;
    }
    
    public void Move(int startTime, int endTime, Vector2 startPosition, Vector2 endPosition,
        Easing easing = Easing.None)
    {
        _commandList.Add(new MoveCommand(this, startTime, endTime, startPosition, endPosition, easing));
    }

    public void Fade(int startTime, int endTime, float startOpacity, float endOpacity,
        Easing easing = Easing.None)
    {
        _commandList.Add(new FadeCommand(this, startTime, endTime, startOpacity, endOpacity, easing));
    }
}