﻿namespace Project.Humans
{
    public abstract class Human
    {
        public Human(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
