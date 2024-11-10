using System.Configuration;
using System.Data;
using System.Windows;

namespace CollectionTracker
{
    public partial class App : Application
    {
        public App()
        {
            // Initialize the database
            using (var context = new CollectionContext())
            {
                context.InitializeDatabase(); // Ensure the database is created and seeded
            }

            InitializeComponent();
        }
    }
}