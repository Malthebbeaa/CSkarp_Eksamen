using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DTO;

namespace Desktop_Application;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var lægehuse = await HentLægehuseAsync();

        if (lægehuse == null) SætLægehusListBox(new string[] { "Ingen lægehuse fundet" });
        
        SætLægehusListBox(lægehuse);
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var ydernummer = Searchbar.Text;
        if (string.IsNullOrWhiteSpace(ydernummer))
        {
            SætLægehusListBox(new string[] { "Ingen lægehuse med dette ydernummer" });
        }
        else
        {
            var lægehus = await HentLægeHusAsync(ydernummer);
            
            if (lægehus == null) SætLægehusListBox(new string[] { "Ingen lægehuse med dette ydernummer" });

            SætLægehusListBox([lægehus]);
        }
    }

    private void Huse_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        OpretReceptBtn.IsVisible = Huse.SelectedItem != null;
    }

    private void OpretReceptBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var formWindow = new ReceptForm((LægehusDTO)Huse.SelectedItem);
        formWindow.Show();
        this.Close();
    }

    private async Task<LægehusDTO?> HentLægeHusAsync(string ydernummer)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync($"http://localhost:5027/api/ReceptSystems/laegehuse/{ydernummer}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var lægehus = JsonSerializer.Deserialize<LægehusDTO>(json, options);
        return lægehus;
    }

    private async Task<List<LægehusDTO>?> HentLægehuseAsync()
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync($"http://localhost:5027/api/ReceptSystems/laegehuse");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var lægehuse = JsonSerializer.Deserialize<List<LægehusDTO>>(json, options);

        return lægehuse;
    }

    private void SætLægehusListBox(IEnumerable<object> list)
    {
        Huse.ItemsSource = list;
    }
}