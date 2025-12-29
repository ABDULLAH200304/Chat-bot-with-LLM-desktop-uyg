using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ChatBotApp
{
    public partial class MainWindow : Window
    {
        private OpenAiService _openAiService;
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        public MainWindow()
        {
            InitializeComponent();
            ChatListBox.ItemsSource = Messages;
        }

        private void SetKey_Click(object sender, RoutedEventArgs e)
        {
            string apiKey = ApiKeyBox.Password;
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("Please enter a valid API key.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _openAiService = new OpenAiService(apiKey);
                MessageBox.Show("API Key set successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize OpenAI service: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await SendMessage();
            }
        }

        private async System.Threading.Tasks.Task SendMessage()
        {
            if (_openAiService == null)
            {
                MessageBox.Show("Please set the API Key first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string text = InputTextBox.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            InputTextBox.Clear();
            var userMsg = new ChatMessage("User", text);
            Messages.Add(userMsg);
            ChatListBox.ScrollIntoView(userMsg);

            try
            {
                string response = await _openAiService.GetResponseAsync(new List<ChatMessage>(Messages));
                var aiMsg = new ChatMessage("Assistant", response);
                Messages.Add(aiMsg);
                ChatListBox.ScrollIntoView(aiMsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class RoleToAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string role)
            {
                return role == "User" ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            }
            return HorizontalAlignment.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}