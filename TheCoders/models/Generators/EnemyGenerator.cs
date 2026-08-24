using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models.Generators
{
    public static class EnemyGenerator
    {
        private static readonly string[] possibleNames = { "Bartholomew", "Dewy", "Travis Scott", "Kevin Lamar", "Katy Perry", "Jeffery Dalmer", "Donald Trump", "Donald Of Trump", "Freddie Mercury", "Orel", "Sid", "Sid The Sloth", "Turbo The Snail", "Lady Gaga", "Talor Swift", "Sony The Company", "Data Center", "Geofery Bezos", "Helen Keller", "Hellen Degenerate", "Person with glasses", "Imposter", "Sam Altmen", "Adam Sandler", "Tom Cruise", "Mr. Krebs", "Herobrine From Minecraft", "Mr. Krabs" };
        private const float statScaler = 1.04f;
        private const int baseDamage = 3;
        private const int baseSpeed = 3;
        private const int baseHealth = 100;
        private const int minGold = 20, maxGold = 100;
        private static Random random = new Random();
        /// <summary>
        /// Generates a random enemy with stats scaled to the current level by the formula "1.04^level"
        /// </summary>
        /// <param name="level">A modifier to adjust how strong the generated enemy is</param>
        /// <returns>A single enemy</returns>
        public static Enemy GenerateOneEnemy(int level)
        {
            double scale = Math.Pow(statScaler, level);
            int health = (int)Math.Round((baseHealth + random.Next(11) - 5) * scale);
            int damage = (int)Math.Round((baseDamage + random.Next(2) - 1) * scale);
            int speed = (int)Math.Round((baseSpeed + random.Next(5) - 2) * scale);
            int nameIndex = random.Next(possibleNames.Length);
            string name = possibleNames[nameIndex];
            int gold = (int)Math.Round((random.Next(minGold, maxGold + 1)) * (random.NextDouble() + .75));
            Element element = GenerateElement(level);
            return new Enemy(name, health, damage, speed, element, gold);
        }

        private static Element GenerateElement(int level)
        {
            List<Element> elements = new List<Element>();
            elements.Add(Element.normal);
            elements.Add(Element.normal);
            if (level >= 1)
                elements.Add(Element.water);
            if (level >= 2)
                elements.Add(Element.water);
            if (level >= 3)
                elements.Add(Element.earth);
            if (level >= 4)
                elements.Add(Element.earth);
            if (level >= 5)
                elements.Add(Element.fire);
            if (level >= 6)
                elements.Add(Element.fire);
            if (level >= 7)
                elements.Add(Element.air);
            if (level >= 8)
                elements.Add(Element.air);
            int elementNum = random.Next(elements.Count);
            return elements[elementNum];

        }

        /// <summary>
        /// Uses the GenerateOneEnemy Method to make multiple enemies
        /// </summary>
        /// <param name="level">A modifier to adjust how strong the generated enemy is</param>
        /// <param name="amount">How many enemies to make</param>
        /// <returns>An Enemy Array full of not ai generated enemies</returns>
        public static Enemy[] GenerateEnemies(int level, int amount)
        {
            Enemy[] enemies = new Enemy[amount];
            for (int i = 0; i < enemies.Length; i++)
                enemies[i] = GenerateOneEnemy(level);
            return enemies;
        }

        /// <summary>
        /// Generates a random amount of enemies between 2 values
        /// </summary>
        /// <param name="level">A modifier to adjust how strong the generated enemy is</param>
        /// <param name="minEnemies">The minimum amount of enemies to generate</param>
        /// <param name="maxEnemies">The maximum amount of enemies to generate (Inclusive)</param>
        /// <returns></returns>
        public static Enemy[] GenerateRangeOfEnemies(int level, int minEnemies, int maxEnemies)
        {
            int enemyAmount = random.Next(minEnemies, maxEnemies + 1);
            Enemy[] enemies = GenerateEnemies(level, enemyAmount);
            return enemies;
        }
    }
}
