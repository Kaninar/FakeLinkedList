using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Lists_LAB
{
    class FakeLinkedList<T>
    {
        FakeListElement<T> head { get; set; }
        FakeListElement<T> tail { get; set; }
        
        public FakeListElement<T> Current { get; set; }
        public int Count { get; set; }
        //
        //  просто создать список
        //
        public FakeLinkedList() {}
        //
        // Создать список через коллекцию
        //
        public FakeLinkedList(IEnumerable<T> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);
            
            foreach (T item in collection)
            {
                AddEnd(item);
            }
            Current = this.head;
        }
        public void AddEnd(T item)
        { 
            FakeListElement<T> new_element = new(item);
            
            if (this.head != null)
            {
                this.Last().Next = new_element;
                new_element.Previous = tail;
                tail = new_element;
            }
            else
            {
                new_element.Previous = null;
                this.head= new_element;
                this.tail = new_element;
            }
            this.Count++;
        }
        public void AddStart(T item)
        {
            FakeListElement<T> new_element = new(item)
            {
                Next = this.head
            };
            if(this.head != null)
                this.head.Previous = new_element;

            if (this.Current == this.head)
                this.Current = new_element;
            this.head = new_element;
            this.Count++;
        }
        public void InsertAfter(FakeListElement<T> prev_item, T item)
        {
            FakeListElement<T> newNode = new (item);
            newNode.Next = prev_item.Next;
            prev_item.Next = newNode;
            newNode.Previous = prev_item;
            if (newNode.Next != null)
                newNode.Next.Previous = newNode;
            this.Count++;
        }
        public void Delete(FakeListElement<T> item)
        {
            if (this.Count == 0)
                return;
            DeleteByValue(item.Value);
        }
        public FakeListElement<T> First()
        {
            return this.head;
        }
        public FakeListElement<T> Last()
        {
            return this.tail;
        }
        public void InsertBefore(FakeListElement<T> next_item, T item) 
        {
            FakeListElement<T> newNode = new(item);
            newNode.Next = next_item.Next;
            newNode.Previous = next_item.Previous;
            next_item.Previous = newNode;
            this.Count++;
        }
        public void DeleteByValue(T item)
        {
            FakeListElement<T> temp = this.head;
            if (temp != null && temp.Value.Equals(item))
            { 
                this.head = temp.Next;
                this.head.Previous = null;
                this.Count--;
                this.Current = this.head;
                return;
            }

            while (temp != null && !temp.Value.Equals(item))
                temp = temp.Next;

            if (temp == null)
                return;

            this.Count--;

            if (temp.Next != null)
                temp.Next.Previous = temp.Previous;

            if (temp.Previous != null)
                temp.Previous.Next = temp.Next;
        }
        public FakeListElement<T> MoveForward()
        {
            if (Current.Next != null)
            {
                Current = Current.Next;
                return Current;
            }
            return null;
        }
        public FakeListElement<T> MoveBackward()
        {
            if (Current.Previous != null)
            {
                Current = Current.Previous;
                return Current;
            }
            return null;
        }
        public void ResetCurrent()
        {
            this.Current = this.head;
        }
    }
    public unsafe class FakeListElement<T>
    { 
        public T Value { get; set; }
        public FakeListElement<T> Next { get; set; }
        public FakeListElement<T> Previous { get; set; }
        public FakeListElement(T value)
        { 
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
