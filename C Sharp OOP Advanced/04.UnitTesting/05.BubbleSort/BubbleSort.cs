using System;


   public class BubbleSort
    {
        public int[] Collection { get; set; }

        public BubbleSort(int[] collection)
        {
            Collection = collection;
        }

        public void Sort()
        {
            var index = 0;

            while (true)
            {
                var currentElement = Collection[index++];
                if (index == Collection.Length)
                {
                    break;
                }

                var nextElement = Collection[index];
                if (currentElement > nextElement)
                {
                    Collection[index - 1] = nextElement;
                    Collection[index] = currentElement;
                    index = 0;
                }
            }
        }
    }

