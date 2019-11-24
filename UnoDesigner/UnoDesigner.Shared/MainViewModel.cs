using System.Collections.ObjectModel;
using UnoDesigner.Shapes;

namespace UnoDesigner
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Rectangle
                {
                    Height = 100,
                    Left = 180,
                    Top = 200,
                    Width = 150,
                },
                new Rectangle
                {
                    Height = 40,
                    Left = 200,
                    Top = 100,
                    Width = 80,
                },
                new Rectangle
                {
                    Height = 20,
                    Left = 10,
                    Top = 30,
                    Width = 40,
                },
                new Picture
                {
                    Source = "mario.png",
                    Left = 400,
                    Top = 200,
                    Width = 300,
                    Height = 340,
                },
                new Picture
                {
                    Source = "block.png",
                    Left = 400,
                    Top = 100,
                    Width = 100,
                    Height = 100,
                }
            };
        }

        public ObservableCollection<Item> Items { get; }
    }
}