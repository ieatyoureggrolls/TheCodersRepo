using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public static class EnemyGenerator
    {
        private const float statScaler = 1.04f;
        private const int baseDamage = 1;
        private const int baseSpeed = 3;
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
            int damage = (int)Math.Round((baseDamage + random.Next(2)) * scale);
            int speed = (int)Math.Round((baseSpeed + random.Next(5) - 2) * scale);
            return new Enemy("Izak (he really wanted his name first but wont admit it), Lucas, Austin, Zach | Roots", health, damage, speed, Element.normal);
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
