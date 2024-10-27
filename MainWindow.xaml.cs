using CollectionTracker.Data;
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
using CollectionTracker.Models;


namespace CollectionTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCollectionButton_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new CollectionContext())
            {

                var collection = new Collection
                {
                    Name = CollectionNameTextBox.Text,
                    Description = "Description here", // Optionally add another input for description
                    UserId = 1 // Use the ID of the current user
                };

                context.Collections.Add(collection);

                try
                {
                    context.SaveChanges();
                    LoadCollections(); // Refreshes the CollectionsListView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void LoadCollections()
        {
            using (var context = new CollectionContext())
            {

                CollectionsListView.ItemsSource = context.Collections.ToList();
            }
        }
    }
}