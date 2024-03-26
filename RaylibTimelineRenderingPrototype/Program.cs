using Raylib_cs;
using RaylibTimelineRenderingPrototype.Commands;

namespace RaylibTimelineRenderingPrototype;

using static Raylib;
using static Game;

internal class Program
{
    public static void Main() => new Program().Run();

    private TimeManager _timeManager = new();
    
    private void Run()
    {
        List<Command> commandList = [];
        new Particles().Generate().ForEach(x => commandList.AddRange(x.GetCommandList()));   
        
        
        InitWindow(ScreenWidth, ScreenHeight, "TimelineRenderingPrototype");

        SetTargetFPS(120); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------
        
        _timeManager.Start();
        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            CheckInput();
            
            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            commandList.ForEach(x => x.Execute((int)_timeManager.GetElapsedMilliseconds()));
            
            DrawFPS(10, 10);
            DrawText(((int)_timeManager.GetElapsedMilliseconds() / 1000.0).ToString("F"), 10, 25, 20, Color.SkyBlue);
            
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    private void CheckInput()
    {
        if (IsKeyPressed(KeyboardKey.Space))
        {
            _timeManager.Pause();
        }

        if (IsKeyPressed(KeyboardKey.Right))
        {
            _timeManager.GoForward();
        }
        
        if (IsKeyPressed(KeyboardKey.Left))
        {
            _timeManager.GoBackwards();
        }

        if (IsKeyPressed(KeyboardKey.R))
        {
            _timeManager.Restart();
        }
    }
}