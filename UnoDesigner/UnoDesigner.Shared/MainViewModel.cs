using System.Collections.ObjectModel;

namespace UnoDesigner
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<Item>()
            {
                new Item()
                {
                    Height = 100,
                    Left = 10,
                    Top = 200,
                    Width = 150,
                }
            };
        }

        public ObservableCollection<Item> Items { get; set; }
    }
}