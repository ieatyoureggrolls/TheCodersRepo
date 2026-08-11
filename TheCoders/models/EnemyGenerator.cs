using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public static class EnemyGenerator
    {
        private const int baseHealth = 10;
        private const int baseDamage = 1;
        private const int baseSpeed = 3;
        private static Random random = new Random();
        /// <summary>
        /// Generates a random enemy based off of the level
        /// </summary>
        /// <param name="level">A modifier to adjust how strong the generated enemy is (not implemented yet)</param>
        /// <returns>A single enemy</returns>
        public static Enemy GenerateOneEnemy(int level)
        {
            int health = baseHealth + random.Next(11) - 5;
            int damage = baseDamage + random.Next(2);
            int speed = baseSpeed + random.Next(5) - 2;
            return new Enemy("This guy was randomly generated and now their name will be incredibly long for no good reason other then why not", health, damage, speed, Element.normal);
        }

        /// <summary>
        /// Uses the GenerateOneEnemy Method to make multiple enemies
        /// </summary>
        /// <param name="level">A modifier to adjust how strong the generated enemy is (not implemented yet)</param>
        /// <param name="amount">How many enemies to make</param>
        /// <returns>An Enemy Array full of not ai generated enemies</returns>
        public static Enemy[] GenerateEnemies(int level, int amount)
        {
            Enemy[] enemies = new Enemy[amount];
            for (int i = 0; i < enemies.Length; i++)
                enemies[i] = GenerateOneEnemy(level);
            return enemies;
        }
    }
}
