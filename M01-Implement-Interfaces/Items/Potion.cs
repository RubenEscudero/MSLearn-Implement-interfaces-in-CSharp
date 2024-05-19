﻿namespace M01_Implement_Interfaces.Items
{
    public enum PotionModifier
    {
        Max,
        Strong,
        Medium,
        Weak
    }

    public enum PotionType
    {
        Health,
        Strength,
        Defense,
        Magic,
        Mana,
        Speed
    }

    internal class Potion : Item, IConsumable
    {
        private PotionModifier modifier;

        public Potion(string name, Bitmap image) : base(ParseName(name), image) 
        {
            string strength = name.Substring(0, name.IndexOf("_"));
            PotionModifier.TryParse(strength, true, out modifier);
        }
        
        private static string ParseName(string name)
        {
            string type = name.Substring(0, name.IndexOf("_"));
            name = name.Substring(name.IndexOf("_")).Replace("_", " ");
            string append = " potion";
            PotionModifier.TryParse(type, true, out PotionModifier modifier);
            switch (modifier)
            { 
                case PotionModifier.Max:
                    append = "max" + append;
                    break;
                case PotionModifier.Strong:
                    append = "++" + append;
                    break;
                case PotionModifier.Medium:
                    append = "+" + append;
                    break;

            }
            return name + append;
        }

        public void Consume()
        {
            Consumed = true;
        }

        protected override int InternalSortOrder { get { return 4;} }

        public bool Consumed { get; set; }
    }
}
