namespace ProcessorScheduling
{
    public struct Task
    {
        public Task(int value, int deadline, int index)
        {
            this.Value = value;
            this.Deadline = deadline;
            this.Index = index;
        }

        public int Value { get; }

        public int Deadline { get; }

        public int Index { get; }

        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
}
