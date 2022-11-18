using ApprovalTests;
using ApprovalTests.Reporters;
using Moq;
using SudokuKata.Service;
using SudokuKata.Service.Rand;

namespace SudokuKata.Test;

[UseReporter(typeof(DiffReporter))]
public class GoldenMaster: IDisposable
{
    private SudokuSolver solver;
    private StringWriter writer;
    private Mock<RandomIntegers> random;
    private int index;

    public GoldenMaster()
    {
        index = 0;
        random = new Mock<RandomIntegers>();
        writer = new StringWriter();
        solver = new SudokuSolver(random.Object);
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
        random.Setup(x => x.Next()).Returns(FakeRandom);
        Console.Clear();
        Console.SetOut(writer);
        solver.Play();
        Approvals.Verify(writer);
    }

    public int FakeRandom()
    {

        if (index == 10)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        return index;
    }
}
