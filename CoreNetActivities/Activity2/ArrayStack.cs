namespace Activity2
{
    public class ArrayStack<T> : ArrayBase<T>
    {
        // NOTE: You are not allowed to declare any additional member variables or methods.

        // HINTS: Use properties and methods that are available from the class BaseArray<T> and are accessible by this class via inheritance.
        // The indexer this[] is used to represent the stack items.
        // The property Count represents the number of items currently in the stack.
        // The methods IsFull() and Contains() from BaseArray can be used here directly.

        /// <summary>
        /// Constructor to initialize the data structure to the specified size.
        /// Calls the overloaded base class constructor passing the size of the array.
        /// </summary>
        /// <param name="size">The maximum length of the stack.</param>
        public ArrayStack(int size) : base(size)
        {

        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ArrayStack()
        {

        }

        /// <summary>
        /// Pushes the 'arg' item on the top of the stack.
        /// </summary>
        /// <param name="arg">Object to push on the top of the stack.</param>
        /// <returns></returns>
        public virtual void Push(T arg)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Stack is full. Cannot push more items.");
            }

            if (Contains(arg))
            {
                return;
            }

            this[Count] = arg;
            Count++;
        }

        /// <summary>
        /// Pops and returns the topmost item from the stack.
        /// </summary>
        /// <returns>current count of the data store</returns>
        public virtual T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty. Cannot pop an item.");
            }

            Count--;
            T topItem = this[Count];
            this[Count] = default;

            return topItem;
        }

        /// <summary>
        /// Returns the topmost item of the stack without removing it.
        /// </summary>
        /// <returns></returns>
        public virtual T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty. Cannot peek.");
            }

            return this[Count - 1];
        }
    }
}