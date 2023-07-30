using Activity2;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Activity3
{
    /// <summary>
    /// Summary description for ArrayQueue.
    /// </summary>
    public class ArrayQueue<T> : ArrayBase<T>
    {
        // The following instance variables are accessible to all methods inside this class. You are not allowed to declare additional class members.

        // The indices of the first and last objects in the queue:
        private int first;

        private int last;

        // HINT: In addition to the above variables,
        // the indexer this[] (represents the queue)
        // and the Count (represents the number of objects inside the queue)
        // can be used also in this class because of inheritance.

        // HINT: Also the methods IsFull() and Contains() from ArrayBase<T>
        // can be used in this class because of inheritance.

        /// <summary>
        ///     Default constructor. Calls the base constructor.
        /// </summary>
        public ArrayQueue()
        {

        }

        /// <summary>
        ///     Constructor to initialize the data structure to the specified size.
        ///     Call the overloaded base class constructor and pass the size of the array.
        /// </summary>
        /// <param name="size">The maximum length of the array.</param>
        public ArrayQueue(int size) : base(size)
        {
            
        }

        /// <summary>
        ///     Method to accept an object and add to the end of the queue.
        /// </summary>
        /// <param name="next">object to enqueue</param>
        /// <returns></returns>
        public virtual bool Enqueue(T next)
        {
            #region Activity 3.0
            if (next == null)
            {
                throw new ArgumentNullException();
            }

            if (IsFull() || IndexOf(next) != NOT_IN_STRUCTURE)
            {
                return false;
            }

            base[last] = next;
            last = (last + 1) % base.Capacity;
            Count++;
            return true;
            #endregion
        }

        /// <summary>
        ///     Method to remove the object from the queue.
        /// </summary>
        /// <returns></returns>
        public virtual T Dequeue()
        {
            #region Activity 3.1
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T removedItem = base[first];
            base[first] = default(T);
            first = (first + 1) % base.Capacity;
            Count--;
            return removedItem;
            #endregion
        }

        /// <summary>
        ///     Method to check an object at the beginning of the queue.
        /// </summary>
        /// <returns></returns>
        public T CheckNext()
            => base[first];

        /// <summary>
        ///     Method to check whether there is any other object in the queue.
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
            => (base.Count != 0);

        /// <summary>
        ///     Method to accept an object and find whether the object exists in the array structure.
        /// </summary>
        /// <param name="arg">object</param>
        /// <returns></returns>
        public override int IndexOf(T arg)
        {
            #region Activity 3.2
            if (arg == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < Count; i++)
            {
                int index = (first + i) % base.Capacity;
                if (base[index].Equals(arg))
                    return i;
            }

            return NOT_IN_STRUCTURE;
            #endregion
        }

        /// <summary>
        ///     Method to accept the index of for and array object and return the corresponding object.
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>the object for the specified index</returns>
        public T Check(int index)
        {
            #region Activity 3.3
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            int arrayIndex = (first + index) % base.Capacity;
            return base[arrayIndex];
            #endregion
        }
    }
}