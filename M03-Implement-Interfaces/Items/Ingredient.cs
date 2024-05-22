﻿namespace M03_Implement_Interfaces.Items
{
    internal class Ingredient : Food, ICombinable
    {
        public Ingredient(string resouceName, Bitmap image) : base(ParseResourceName(resouceName), image)
        {
            Random random = new();
            healthBoost = 5 + random.Next(0, 5);
        }

        private static new string ParseResourceName(string name)
        {
            if (name.StartsWith("ingredient"))
                name = name[name.IndexOf("_")..].Trim();

            return name.Replace("_", " ").Trim();
        }

        public Item? Combine(Item item)
        {
            if (CanCombine(item))
               return CreateRandomFood();
            
            return null;
        }

        public bool CanCombine(Item item)
        {
            if (item != null && item is Ingredient)
                return true;
            
            return false;
        }

        protected override int InternalSortOrder { get { return 3; } }
    }
}
