namespace ProcessData;

public class Context
{
    private IChooseStrategy _strategy;

    public Context()
    {

    }

    public Context(IChooseStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IChooseStrategy strategy)
    {
        _strategy = strategy;
    }

    public string ExecuteStrategy()
    {
        return _strategy.Choose();
    }
}
