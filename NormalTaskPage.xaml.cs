namespace Lists_LAB;

public partial class NormalTaskPage : ContentPage
{
	public NormalTaskPage()
	{
		InitializeComponent();
        GenerateList();
	}
    FakeLinkedList<double> list;
    public void GenerateList()
    {
        Random random = new Random();
        list = new FakeLinkedList<double>(Enumerable
                                            .Repeat(0, 10)
                                            .Select(i => random.NextDouble() + (double)random.Next(-10, 10))
                                            .ToArray());
    }
    public void Task()
    {
        while (list.Current.Next != null)
        {
            if (list.Current.Value < 0)
                list.InsertAfter(list.Current, 1.5);
            list.MoveForward();
        }
    }
}