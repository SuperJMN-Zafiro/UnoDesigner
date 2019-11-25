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
                    Source =
                        "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/ed991cf4-7c8c-4530-b6ba-a3abf3ab2eae/dc6iasu-28eb3a37-3ff0-4623-8611-0112c61af2b3.png/v1/fill/w_600,h_680,strp/super_mario__classic_mario_2d_by_joshuat1306_dc6iasu-fullview.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NjgwIiwicGF0aCI6IlwvZlwvZWQ5OTFjZjQtN2M4Yy00NTMwLWI2YmEtYTNhYmYzYWIyZWFlXC9kYzZpYXN1LTI4ZWIzYTM3LTNmZjAtNDYyMy04NjExLTAxMTJjNjFhZjJiMy5wbmciLCJ3aWR0aCI6Ijw9NjAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.gFzmGR_ZuiHRU8rRIUqxiRTXVMAFLNOerxT252joBis",
                    Left = 400,
                    Top = 200,
                    Width = 300,
                    Height = 340,
                },
                new Picture
                {
                    Source =
                        "http://vignette2.wikia.nocookie.net/mario/images/0/08/Bloque_Ladrillo.png/revision/latest?cb=20101208121924&path-prefix=es",
                    Left = 400,
                    Top = 100,
                    Width = 100,
                    Height = 100,
                },
                new Picture
                {
                    Source = "http://findicons.com/files/icons/2297/super_mario/256/paper_lakitu.png",
                    Left = 200,
                    Top = 180,
                    Width = 200,
                    Height = 200,
                },
                new Picture
                {
                    Source =
                        "http://vignette2.wikia.nocookie.net/papermario/images/4/4e/Goomba.png/revision/latest?cb=20120704200900",
                    Left = 100,
                    Top = 70,
                    Width = 200,
                    Height = 200,
                }
            };
        }

        public ObservableCollection<Item> Items { get; }
    }
}