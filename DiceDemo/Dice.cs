public class Dice
{
    // Private fields (instance variables) as defined in the UML
    private int numberOfSides;
    private int topSide;

    // Static and read-only field for generating random numbers. 
    // Static ensures all Dice instances share the same efficient random number generator.
    private static readonly Random random = new Random();

    // Public read-only properties (getters) to access the private fields externally.
    // This follows the UML and C# property best practices.
    public int NumberOfSides => numberOfSides;
    public int TopSide => topSide;

    /// <summary>
    /// Default constructor. Initializes a standard 6-sided die.
    /// </summary>
    public Dice() : this(6)
    {
        // Constructor chaining to call the primary constructor with a default value.
    }

    /// <summary>
    /// Primary constructor. Initializes a die with a specified number of sides.
    /// </summary>
    /// <param name="numOfSides">The desired number of sides (must be greater than 1).</param>
    public Dice(int numOfSides)
    {
        if (numOfSides < 2)
        {
            // Ensure a valid number of sides for the die.
            throw new ArgumentException("A die must have at least 2 sides.");
        }
        this.numberOfSides = numOfSides;
        // Roll the die once immediately after creation to set an initial value.
        this.topSide = Roll();
    }

    /// <summary>
    /// Rolls the die, generating a new random value between 1 and the number of sides.
    /// </summary>
    /// <returns>The integer value of the new top side.</returns>
    public int Roll()
    {
        // Generate a random number from 1 up to (and including) numberOfSides.
        this.topSide = random.Next(1, numberOfSides + 1);
        return this.topSide;
    }
}