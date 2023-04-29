﻿using Shared.Properties;

namespace Solution.Items
{
    internal class Food : Item, IConsumable
    {
        private static Random random = new();
        protected int healthBoost;

        public Food(string resouceName, Bitmap image) : base(ParseResourceName(resouceName), image)
        {
            healthBoost = 10 + random.Next(0, 25);
        }

        public Food(string name, Bitmap image, bool ingredient) : base(name, image)
        {
            healthBoost = 10 + random.Next(0, 25);
        }

        public bool Consumed { get; set; }

        public void Consume()
        {
            Player.hp += healthBoost;
            Consumed = true;
        }

        protected Food CreateRandomFood()
        {
            int combination = random.Next(1, 6);
            string name;
            Bitmap image;
            switch (combination)
            {
                case 1:
                    name = "lasagna";
                    image = Resources.food_combined_1;
                    break;
                case 2:
                    name = "soup";
                    image = Resources.food_combined_2;
                    break;
                case 3:
                    name = "burger";
                    image = Resources.food_combined_3;
                    break;
                case 4:
                    name = "trifle";
                    image = Resources.food_combined_4;
                    break;
                default:
                    name = "pastry";
                    image = Resources.food_combined_5;
                    break;
            }
            return new Food(name, image, false);
        }

        private static new string ParseResourceName(string name)
        {
            if (name.StartsWith("ingredient"))
                name = name[name.IndexOf("_")..].Trim();

            return name.Replace("_", " ").Trim();
        }

        protected override int InternalSortOrder { get { return 3; } }
    }
}
