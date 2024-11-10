using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public static class PlaceholderService
{
    public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
        "Placeholder", typeof(string), typeof(PlaceholderService), new PropertyMetadata(default(string), OnPlaceholderChanged));

    public static void SetPlaceholder(DependencyObject element, string value)
    {
        element.SetValue(PlaceholderProperty, value);
    }

    public static string GetPlaceholder(DependencyObject element)
    {
        return (string)element.GetValue(PlaceholderProperty);
    }

    private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TextBox textBox)
        {
            textBox.GotFocus += RemovePlaceholder;
            textBox.LostFocus += AddPlaceholder;

            AddPlaceholder(textBox, null);
        }
    }

    private static void AddPlaceholder(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
        {
            textBox.Text = GetPlaceholder(textBox);
            textBox.Foreground = Brushes.Gray;
        }
    }

    private static void RemovePlaceholder(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && textBox.Text == GetPlaceholder(textBox))
        {
            textBox.Text = "";
            textBox.Foreground = Brushes.Black;
        }
    }
}
