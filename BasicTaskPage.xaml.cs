using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace Lists_LAB;

public partial class BasicTaskPage : ContentPage
{
    public BasicTaskPage()
    {
        InitializeComponent();
        GenerateList();
        BindingContext = this;
        Show();
    }
    FakeLinkedList<double> list;
    ObservableCollection<Item<double>> collection = new ObservableCollection<Item<double>>(); 
    public void GenerateList()
    {
        Random random = new Random();
        list = new FakeLinkedList<double>(Enumerable
                                            .Repeat(0, 10)
                                            .Select(i => (double)random.Next(-10, 20))
                                            .ToArray());
    }
    public void Task()
    {
        int seven_counter = 0;
        list.ResetCurrent();
        while (list.Current.Next != null)
        { 
            if(list.Current.Value > 7)
                seven_counter++;
            list.MoveForward();
        }
        DisplayAlert("Ответ", seven_counter.ToString(), "OK");
        //Show();
    }
    public void Show()
    {
        list.ResetCurrent();
        collection.Clear();
        for (int i = 0; i < list.Count; i++) 
        {
            collection.Add(new Item<double>(list.Current.Value));
            list.MoveForward();
        }
        ListV.ItemsSource = null;
        ListV.ItemsSource = collection;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Task();
        Show();
    }
}