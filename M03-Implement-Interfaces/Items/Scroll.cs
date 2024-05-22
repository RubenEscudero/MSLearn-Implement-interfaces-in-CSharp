namespace M03_Implement_Interfaces.Items
{
    internal class Scroll : Item, IReadable
    {
        public Scroll(string resourceName, Bitmap image) : base(ParseResourceName(resourceName), image) 
        { 
            // Nothing to do for now
        }

        public bool Readed { get; set; }

        protected override int InternalSortOrder { get { return 5; } }

        public void MarkAsNew()
        {
            Readed = false;
        }

        public void Read()
        {
            Readed = true;
        }
    }
}
