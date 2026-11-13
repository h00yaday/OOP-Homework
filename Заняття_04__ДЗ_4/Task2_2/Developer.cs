namespace Task2_2
{
    public class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Position = "Розробник";
        }

        // За умовою: WriteCode(), Call(), Relax(), WriteCode()
        public override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }
}
