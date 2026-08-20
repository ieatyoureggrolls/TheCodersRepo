using System;
using System.Collections.Generic;
using System.Text;
using TheCoders.controllers;

namespace TheCoders.models
{
    public static class Endless
    {
        public static int currentLevel;
        public static Person[] partyMembers = { new Person("Bob", 10000, 250, 250, true), new Person("Billy", 25, 3, 6, true), new Person("Joe", 50, 1, 1, true) };

        public static void StartEndless()
        {
            Console.WriteLine("Welcome To Endless");
            bool partyAlive;
            do
            {
                partyAlive = LevelLoop.Wave(currentLevel, partyMembers);
                currentLevel++;
            } while (partyAlive);
        }
    }
}
