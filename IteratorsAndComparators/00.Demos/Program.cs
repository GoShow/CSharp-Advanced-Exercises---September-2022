using System;
using System.Collections;
using System.Collections.Generic;

namespace _00.Demos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stadium staduim = new Stadium();

            foreach (var seat in staduim)
            {
                Console.WriteLine(seat);
            }
        }
    }


    public class Stadium : IEnumerable<int>
    {
        public Stadium()
        {
            Seats = new List<int> { 1, 2, 3 };
        }

        public List<int> Seats { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            //return new StadiumEnumerator();

            foreach (var seat in Seats)
            {
                yield return seat;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class StadiumEnumerator : IEnumerator<int>
    {
        private int index = -1;
        private List<int> seats;

        public StadiumEnumerator(List<int> seats)
        {
            this.seats = seats;
        }

        public int Current
        {
            get { return seats[index]; }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index++;

            return index < seats.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
        }
    }
}
