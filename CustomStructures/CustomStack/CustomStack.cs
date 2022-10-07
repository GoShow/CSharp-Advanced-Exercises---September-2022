using System;

namespace CustomStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;

        public CustomStack()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int item)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count] = item;

            this.Count++;
        }

        public int Pop()
        {
            this.IsEmpty();

            int removedItem = this.items[this.Count - 1];

            this.items[this.Count - 1] = default(int);

            this.Count--;

            //TODO Shrink if needed

            return removedItem;
        }

        public int Peek()
        {
            this.IsEmpty();

            return this.items[this.Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int currentItem = this.items[i];

                action(currentItem);
            }

            //Reversed if preferred
            //for (int i = this.Count - 1; i >= 0; i--)
            //{
            //    int currentItem = this.items[i];

            //    action(currentItem);
            //}
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
        }
    }
}
