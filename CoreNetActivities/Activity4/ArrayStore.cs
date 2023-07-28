using System;
namespace Activity4
{
    public class ArrayStore<T> : AbstractArrayStore<T>
    {
        public ArrayStore(int arraySize) : base(arraySize)
        {
        }

        public override int Add(T argToAdd)
        {
            if (argToAdd == null)
            {
                throw new ArgumentNullException();
            }

            if (IsFull())
            {
                return NOT_IN_STRUCTURE;
            }

            base[Count] = argToAdd;
            Count++;
            return Count - 1;
        }

        public override int Insert(T argToInsert, int indexToInsert)
        {
            if(argToInsert == null)
            {
                throw new ArgumentNullException();
            }

            if(indexToInsert < 0 || indexToInsert > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (IsFull())
            {
                return NOT_IN_STRUCTURE;
            }

            for (int i = Count; i > indexToInsert; i--)
            {
                base[i] = base[i - 1];
            }

            base[indexToInsert] = argToInsert;
            Count++;
            return indexToInsert;
        }

        public override void Remove(T argToRemove)
        {
            if (argToRemove == null)
                throw new ArgumentNullException();

            int indexToRemove = IndexOf(argToRemove);

            if (indexToRemove == NOT_IN_STRUCTURE)
            {
                throw new InvalidOperationException();
            }
            else
            {
                RemoveAt(indexToRemove);
            }
        }

        public override void RemoveAt(int removeObjectIndex)
        {
            if(removeObjectIndex >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = removeObjectIndex; i < Count - 1; i++)
            {
                base[i] = base[i + 1];
            }

            base[Count - 1] = default(T);
            Count--;
        }
    }
}
