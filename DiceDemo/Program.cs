using System.Diagnostics;


Console.WriteLine("--- C# Dice Demo Program ---");
Console.WriteLine("----------------------------\n");

// Instantiate the utility class to access the required methods
DiceGame game = new DiceGame();

// --- TEST CASE 1: Compare two dice over 5 rolls (Lab requirement) ---
TestDiceComparison();

Console.WriteLine("\n----------------------------\n");

// --- TEST CASE 2: Testing ContainsNumber method ---
TestContainsNumber(game);

Console.WriteLine("\n----------------------------\n");

// --- TEST CASE 3: Testing GetUniqueRolls method ---
TestGetUniqueRolls(game);

Console.WriteLine("\n--- Demo Complete ---\n");


// --- Helper Methods (defined as local functions for the top-level program) ---

/// <summary>
/// Creates two Dice objects, rolls them 5 times, and compares the results.
/// </summary>
void TestDiceComparison()
{
    Console.WriteLine("TEST 1: Rolling Two Dice (5 Rounds)");
    
    // Create two dice objects: a standard 6-sided and a 10-sided.
    Dice diceA = new Dice(6); 
    Dice diceB = new Dice(10); 
    
    Console.WriteLine($"Dice A: {diceA.NumberOfSides}-sided | Dice B: {diceB.NumberOfSides}-sided");

    int winsA = 0;
    int winsB = 0;
    const int totalRounds = 5;

    // Roll and compare over 5 rounds
    for (int i = 1; i <= totalRounds; i++)
    {
        int rollA = diceA.Roll();
        int rollB = diceB.Roll();

        string winner;
        if (rollA > rollB)
        {
            winsA++;
            winner = "Dice A Wins";
        }
        else if (rollB > rollA)
        {
            winsB++;
            winner = "Dice B Wins";
        }
        else
        {
            winner = "Tie";
        }

        Console.WriteLine($"Round {i}: A({rollA}) vs B({rollB}) -> {winner}");
    }

    Console.WriteLine($"\nFinal Score (out of {totalRounds}): Dice A: {winsA} | Dice B: {winsB} | Ties: {totalRounds - (winsA + winsB)}");
    string overallWinner = (winsA > winsB) ? "Dice A is the overall winner." :
                           (winsB > winsA) ? "Dice B is the overall winner." :
                           "The game ended in a draw.";
    Console.WriteLine(overallWinner);
}

/// <summary>
/// Tests the ContainsNumber utility method.
/// </summary>
void TestContainsNumber(DiceGame game)
{
    Console.WriteLine("TEST 2: ContainsNumber Utility");

    // Simulate the rolls array from the requirement (tracking top sides after rolling N times)
    int[] testRolls = { 5, 2, 6, 1, 4 };
    Console.WriteLine($"Roll History: [{string.Join(", ", testRolls)}]");

    int searchNumber1 = 6;
    bool found1 = game.ContainsNumber(testRolls, searchNumber1);
    Console.WriteLine($"\tDoes it contain {searchNumber1}? {found1}");

    int searchNumber2 = 3;
    bool found2 = game.ContainsNumber(testRolls, searchNumber2);
    Console.WriteLine($"\tDoes it contain {searchNumber2}? {found2}");
}

/// <summary>
/// Tests the GetUniqueRolls utility method.
/// </summary>
void TestGetUniqueRolls(DiceGame game)
{
    Console.WriteLine("TEST 3: GetUniqueRolls Utility");

    // Use a 4-sided die for a shorter demonstration of uniqueness.
    Dice d4 = new Dice(4); 
    Console.WriteLine($"Rolling a D{d4.NumberOfSides} until all sides (1-4) are seen.");

    Stopwatch sw = new Stopwatch();
    sw.Start();
    int[] uniqueRollSequence = game.GetUniqueRolls(d4);
    sw.Stop();

    Console.WriteLine($"\tRolls needed: {uniqueRollSequence.Length}");
    Console.WriteLine($"\tRoll Sequence: [{string.Join(", ", uniqueRollSequence)}]");
    Console.WriteLine($"\tTime taken: {sw.ElapsedMilliseconds}ms");
    
    // Verify that all numbers from 1 to 4 are present (just a quick check).
    bool verification = (new HashSet<int>(uniqueRollSequence).Count == d4.NumberOfSides);
    Console.WriteLine($"\tVerification: All {d4.NumberOfSides} sides captured? {verification}");
}