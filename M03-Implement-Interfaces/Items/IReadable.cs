namespace M03_Implement_Interfaces.Items
{
    internal interface IReadable
    {
        public void Read();
        public void MarkAsNew();
        public bool Readed { get; set; }
    }
}