namespace ShrubsBudgetFinance
{
	public class PageNode<T>
	{
		public T Data { get; set; }
		public PageNode<T>? Next { get; set; }
		public PageNode<T>? Previous { get; set; }

		public PageNode(T data)
		{
			this.Data = data;
			Next = null;
			Previous = null;
		}
	}
	public class PageLinkedList<T>
	{
		public PageNode<T>? Head { get; set; }
		public PageNode<T>? Tail { get; set; }
		public PageNode<T>? Current { get; set; }

		public void Add(T data)
		{
			PageNode<T> newNode = new PageNode<T>(data);
			if (Head == null)
			{
				Head = newNode;
				Tail = newNode;
				Current = newNode;
			}
			else
			{
				Tail.Next = newNode;
				newNode.Previous = Tail;
				Tail = newNode;
			}
		}
		public void MoveNext()
		{
			if (Current != null && Current.Next != null)
			{
				Current = Current.Next;
			}
		}
		public void MovePrevious()
		{
			if (Current != null && Current.Previous != null)
			{
				Current = Current.Previous;
			}
		}
		public T? GetCurrentPage()
		{
			return Current != null ? Current.Data : default;
		}
	}
}
