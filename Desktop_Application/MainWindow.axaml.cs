using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Desktop_Application;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Huse.ItemsSource = new string[]
        {
            "Viby", "Aarhus", "Bruuns", "Højbjerg"
        };
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Show(new ReceptForm());
    }
}