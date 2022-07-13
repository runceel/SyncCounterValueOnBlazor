namespace BlazorApp2;

public class Notifier
{
    private object _lock = new();
    private EventHandler<CounterChangedEventArgs>? _counterChanged;
    public event EventHandler<CounterChangedEventArgs>? CounterChanged
    {
        add
        {
            lock(_lock)
            {
                _counterChanged += value;
            }
        }
        remove
        {
            lock(_lock)
            {
                _counterChanged -= value;
            }
        }
    }

    public void Notify(int count) => _counterChanged?.Invoke(this, new(count));
}

public class CounterChangedEventArgs : EventArgs
{
    public CounterChangedEventArgs(int count)
    {
        Count = count;
    }

    public int Count { get; }
}
