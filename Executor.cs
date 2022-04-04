//public class Executor : IExecutor
namespace testConsole;
public class Executor : IExecutor
{
    private readonly ITest _test;

    public Executor(ITest test)
    {
        _test = test;
    }

    public void Execute()
    {
        _test.TestMethod();
    }
}