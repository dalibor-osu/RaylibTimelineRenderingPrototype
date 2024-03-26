using Raylib_cs;

namespace RaylibTimelineRenderingPrototype.DrawableObject;

public class Circle(float radius) : Drawable((vector2, color) =>
{
    Raylib.DrawCircleV(vector2, radius, color);
});