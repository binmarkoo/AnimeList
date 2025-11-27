using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnimeListLibrary.Models;

namespace AnimeListWPF
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _client = new HttpClient();
        private List<AnimeItem> _animeList = new List<AnimeItem>();
        private string _apiUrl = "http://localhost:5008/api/AnimeItems";

        public MainWindow()
        {
            InitializeComponent();
            _ = LoadAnimeListAsync();
        }

        public async Task LoadAnimeListAsync()
        {
            try
            {
                _animeList = await _client.GetFromJsonAsync<List<AnimeItem>>(_apiUrl);
                AnimeListView.ItemsSource = null;
                AnimeListView.ItemsSource = _animeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task AddAnimeAsync()
        {
            try
            {
                var newAnime = GetAnimeFromFields();
                newAnime.Id = _animeList.Count > 0 ? _animeList[^1].Id + 1 : 0;
                var response = await _client.PostAsJsonAsync(_apiUrl, newAnime);
                response.EnsureSuccessStatusCode();
                await LoadAnimeListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Hinzufügen: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task UpdateAnimeAsync()
        {
            try
            {
                var updatedAnime = GetAnimeFromFields();
                var response = await _client.PutAsJsonAsync($"{_apiUrl}/{updatedAnime.Id}", updatedAnime);
                response.EnsureSuccessStatusCode();
                await LoadAnimeListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Aktualisieren: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task DeleteAnimeAsync()
        {
            try
            {
                if (int.TryParse(IdTextBox.Text, out int id))
                {
                    var response = await _client.DeleteAsync($"{_apiUrl}/{id}");
                    response.EnsureSuccessStatusCode();
                    await LoadAnimeListAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Löschen: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AnimeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimeListView.SelectedItem is AnimeItem selected)
            {
                IdTextBox.Text = selected.Id.ToString();
                TypeTextBox.Text = selected.Type;
                NameTextBox.Text = selected.Name;
                GenreTextBox.Text = selected.Genre;
                RatingTextBox.Text = selected.Rating.ToString();
                StateTextBox.Text = selected.State;
                ReleaseYearTextBox.Text = selected.ReleaseYear.ToString();
                PicSrcTextBox.Text = selected.PicSrc;
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            await AddAnimeAsync();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            await UpdateAnimeAsync();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            await DeleteAnimeAsync();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            IdTextBox.Clear();
            TypeTextBox.Clear();
            NameTextBox.Clear();
            GenreTextBox.Clear();
            RatingTextBox.Clear();
            StateTextBox.Clear();
            ReleaseYearTextBox.Clear();
            PicSrcTextBox.Clear();
        }

        private AnimeItem GetAnimeFromFields()
        {
            return new AnimeItem
            {
                Id = int.TryParse(IdTextBox.Text, out int id) ? id : 0,
                Type = TypeTextBox.Text,
                Name = NameTextBox.Text,
                Genre = GenreTextBox.Text,
                Rating = int.TryParse(RatingTextBox.Text, out int rating) ? rating : 0,
                State = StateTextBox.Text,
                ReleaseYear = int.TryParse(ReleaseYearTextBox.Text, out int release) ? release : 0,
                PicSrc = PicSrcTextBox.Text
            };
        }
    }
}