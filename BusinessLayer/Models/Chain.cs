﻿namespace BusinessLayer.Models
{
    public class Chain : EditableObject
    {

        public Chain()
        {

        }

        public string Code { get; set; }
        public string Name { get; set; }

        public string CodeAndName { get { return Code + " " + Name; } }

        private void test()
        {
            
        }
    }
}
