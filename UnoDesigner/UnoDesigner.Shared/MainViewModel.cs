using System.Collections.ObjectModel;

namespace UnoDesigner
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Item
                {
                    Height = 100,
                    Left = 180,
                    Top = 200,
                    Width = 150,
                },
                new Item
                {
                    Height = 40,
                    Left = 200,
                    Top = 100,
                    Width = 80,
                },
                new Item
                {
                    Height = 20,
                    Left = 10,
                    Top = 30,
                    Width = 40,
                }
            };
        }

        public ObservableCollection<Item> Items { get; set; }
    }
}