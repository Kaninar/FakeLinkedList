
namespace Lists_LAB;

public partial class HardTaskPage : ContentPage
{
	public HardTaskPage()
	{
		InitializeComponent();
        GenerateList();
    }
    FakeLinkedList<int> list;
    public void GenerateList()
    {
        Random random = new Random();
        list = new FakeLinkedList<int>(Enumerable
                                            .Repeat(0, 10)
                                            .Select(i => random.Next(0, 30))
                                            .ToArray());
    }
    public void Task()
    {
        while (list.Current.Next != null)
        {
            list.MoveForward();
        }
        while (list.Current.Previous != null)
        { 
            if(list.Current.Value < 15) 
            {
                list.Delete(list.Current);
                return;
            }
        }
    }
}