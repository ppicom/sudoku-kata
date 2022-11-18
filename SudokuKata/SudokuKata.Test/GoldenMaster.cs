using ApprovalTests;
using ApprovalTests.Reporters;
using SudokuKata.Service;

namespace SudokuKata.Test;

[UseReporter(typeof(DiffReporter))]
public class GoldenMaster: IDisposable
{
    SudokuSolver solver;
    StringWriter writer;

    public GoldenMaster()
    {
        writer = new StringWriter();
        solver = new SudokuSolver();
        Console.SetOut(writer);
    }

    public void Dispose()
    {
        writer.Dispose();
        Console.Clear();
    }

    [Fact]
    public void TestReproductibility()
    {
        Console.Clear();
        Console.SetOut(writer);
        solver.Play();
        Approvals.Verify(writer);
    }
}
