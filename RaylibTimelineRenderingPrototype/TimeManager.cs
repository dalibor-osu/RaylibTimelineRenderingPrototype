using System.Diagnostics;

namespace RaylibTimelineRenderingPrototype;

public class TimeManager
{
    private readonly Stopwatch _forwardStopwatch = new();
    private readonly Stopwatch _backwardsStopwatch = new();

    private bool _paused = false;
    private TimeFlow _timeFlow = TimeFlow.Forward;
    
    public void Start()
    {
        _forwardStopwatch.Start();
    }

    public void Restart()
    {
        _forwardStopwatch.Reset();
        _backwardsStopwatch.Reset();

        if (_timeFlow == TimeFlow.Forward)
        {
            _forwardStopwatch.Start();
        }
        else
        {
            _backwardsStopwatch.Start();
        }
    }

    public void Pause()
    {
        if (_paused)
        {
            Resume();
            return;
        }
        
        _forwardStopwatch.Stop();
        _backwardsStopwatch.Stop();
        _paused = true;
    }

    public void Resume()
    {
        if (!_paused)
        {   
            return;
        }

        _paused = false;
        
        if (_timeFlow == TimeFlow.Forward)
        {
            _forwardStopwatch.Start();
        }
        else
        {
            _backwardsStopwatch.Start();
        }
    }

    public void GoForward()
    {
        _timeFlow = TimeFlow.Forward;
        _backwardsStopwatch.Stop();
        _forwardStopwatch.Start();
    }
    
    public void GoBackwards()
    {
        _timeFlow = TimeFlow.Backwards;
        _backwardsStopwatch.Start();
        _forwardStopwatch.Stop();
    }

    public long GetElapsedMilliseconds()
    {
        return _forwardStopwatch.ElapsedMilliseconds - _backwardsStopwatch.ElapsedMilliseconds;
    }
    
    enum TimeFlow
    {
        Forward,
        Backwards
    }
}