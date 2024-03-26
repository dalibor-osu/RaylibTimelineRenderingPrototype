using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using RaylibTimelineRenderingPrototype.DrawableObject;
using RaylibTimelineRenderingPrototype.TimeEasing;

namespace RaylibTimelineRenderingPrototype;

public class Particles
{
    private const float StartY = 25;
    private const float EndY = Game.ScreenHeight - 25;

    private const int StartTime = 500;
    private const int EndTime = 20_000;
    private const int TotalTime = EndTime - StartTime;
    
    private const int NumberOfParticles = 1000;
    private const int LifeTime = 1000;

    private const int RandomSeed = 512;
    
    private readonly List<Drawable> _drawableList = [];
    
    
    public List<Drawable> Generate()
    {
        const double generationTime = (double)LifeTime / NumberOfParticles;
        var random = new Random(RandomSeed);

        for (int i = 0; i < NumberOfParticles; i++)
        {
            var circle = new Circle(20);
            
            int xPosition = random.Next(25, Game.ScreenWidth - 25);
            var startPosition = new Vector2(xPosition, StartY);
            var endPosition = startPosition with { Y = EndY };
            
            int currentTime = (int)(StartTime + i * generationTime);
            
            while (currentTime <= EndTime)
            {
                circle.Move(currentTime, currentTime + LifeTime, startPosition, endPosition, Easing.InCubic);
                circle.Fade(currentTime, currentTime + LifeTime, 1, 0, Easing.InCubic);
                currentTime += LifeTime;
            }
            
            _drawableList.Add(circle);
        }

        return _drawableList;
    }
}