using SudokuKata.Service;

var solver = new SudokuSolver();

solver.Play();

Console.WriteLine();
Console.Write("Press ENTER to exit... ");
Console.ReadLine();