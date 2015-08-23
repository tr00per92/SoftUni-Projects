namespace FarmersCreed.Units
{
    using System;

    public abstract class GameObject
    {
        private string id;

        protected GameObject(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Id", "Object id cannot be null.");
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            return string.Format("--{0} {1}", this.GetType().Name, this.id);
        }
    }
}
