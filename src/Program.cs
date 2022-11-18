// See https://aka.ms/new-console-template for more information
using SudokuKata.Domain;

var solver = new SudokuSolver();

solver.Play();

Console.WriteLine();
Console.Write("Press ENTER to exit... ");
Console.ReadLine();