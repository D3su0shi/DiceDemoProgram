public class Dice
{
    private int numberOfSides;
    private int topSide;
    private Random random = new Random();

    public int NumberOfSides => numberOfSides;
    public int TopSide => topSide;

    public Dice() : this(6)
    {
        // Constructor chaining to call the primary constructor with a default value.
    }

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

    public int Roll()
    {
        // Generate a random number from 1 up to (and including) numberOfSides.
        this.topSide = random.Next(1, numberOfSides + 1);
        return this.topSide;
    }
}