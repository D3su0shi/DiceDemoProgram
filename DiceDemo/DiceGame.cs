public class DiceGame
    {
        /// <summary>
        /// Checks if a specified number is present in an array of previous dice rolls.
        /// </summary>
        /// <param name="rolls">The array of integer roll results.</param>
        /// <param name="number">The number to search for.</param>
        /// <returns>True if the number is found in the array, otherwise False.</returns>
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

        /// <summary>
        /// Rolls a specified die repeatedly until an array of unique roll results 
        /// covering all sides (1 to N) is collected.
        /// </summary>
        /// <param name="dice">The Dice object to roll.</param>
        /// <returns>An array of integers representing the rolls needed to get all unique sides.</returns>
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