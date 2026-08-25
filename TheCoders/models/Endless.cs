using System;
using System.Collections.Generic;
using System.Text;
using TheCoders.controllers;

namespace TheCoders.models
{
    public static class Endless
    {
        public static int currentLevel = 1;
        public static int gold = 0;
        public static Person[] partyMembers = { new Person("Bob", 100, 5, 1, true), new Person("Billy", 100, 5, 1, true), new Person("Joe", 100, 5, 1, true) };

        public static void StartEndless()
        {
            Console.WriteLine("Welcome To Endless");
            bool partyAlive;
            do
            {
                LevelLoop.gold = gold;
                partyAlive = LevelLoop.Wave(currentLevel, partyMembers, new List<Weapon>());
                currentLevel++;
                gold = LevelLoop.gold;
            } while (partyAlive);
        }
    }
}
