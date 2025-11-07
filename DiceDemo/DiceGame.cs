public class DiceGame
    {
        public bool ContainsNumber(int[] rolls, int number)
        {
            // Iterate through the array to perform a sequential search.
            foreach (int roll in rolls)
            {
                if (roll == number)
                {
                    return true;
                }
            }
            return false;
        }

        public int[] GetUniqueRolls(Dice dice)
        {
            // Determine the total number of unique sides we need to find.
            int requiredUniqueSides = dice.NumberOfSides;

            // Use a HashSet to efficiently track which sides have been seen (O(1) lookup time).
            HashSet<int> uniqueRolls = new HashSet<int>();

            // Use a List to store the sequence of rolls that occurred.
            List<int> rollSequence = new List<int>();

            // Roll the die until all unique sides (1 to NumberOfSides) are found.
            while (uniqueRolls.Count < requiredUniqueSides)
            {
                int currentRoll = dice.Roll();
                rollSequence.Add(currentRoll);
                uniqueRolls.Add(currentRoll); // HashSet only adds if the value is unique.
            }

            // Convert the List of rolls into an array for the return type defined in the UML.
            return rollSequence.ToArray();
        }
    }