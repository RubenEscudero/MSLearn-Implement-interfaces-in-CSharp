namespace M02_Implement_Interfaces.Items
{
    internal interface ICombinable
    {
        public bool CanCombine(Item item);
        public Items? Combine(Item item);
    }
}