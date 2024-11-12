using CollectionTracker.Models;
using System.Linq;
using System.Windows;

namespace CollectionTracker
{
    public partial class MainWindow : Window
    {
        private int currentUserId;

        public MainWindow(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadCollections(); // Load collections on startup
        }
        private void CollectionsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CollectionsListBox.SelectedItem is Collection selectedCollection)
            {
                // Log to check if the event is triggered
                Console.WriteLine("Collection selected: " + selectedCollection.Name);

                AddItemToCollectionPanel.Visibility = Visibility.Visible;
                ViewCollectionButton.Visibility = Visibility.Visible;
                ViewWishlistButton.Visibility = Visibility.Visible;
                SelectedCollectionName.Text = selectedCollection.Name;
                SelectedCollectionDesc.Text = selectedCollection.Description;

                LoadCollectionItems(selectedCollection.CollectionId);
                ItemsListBox.Visibility = Visibility.Visible;

                // Show controls to add items to the collection
                ItemcatgoryTextBox.Visibility = Visibility.Visible;
                ItemdecTextBox.Visibility = Visibility.Visible;
                ItemseriesTextBox.Visibility = Visibility.Visible;
                itemname.Visibility = Visibility.Visible;
                AddItemToCollectionButton.Visibility = Visibility.Visible;
                ItemNameTextBox.Visibility = Visibility.Visible;



                // Show back button
                BackButton.Visibility = Visibility.Visible;

                // Hide other controls
                wishlistwannring.Visibility = Visibility.Collapsed;
                CollectionNameTextBox.Visibility = Visibility.Collapsed;
                CollectiondecTextBox.Visibility = Visibility.Collapsed;
                AddCollectionButton.Visibility = Visibility.Collapsed;
                CollectionsListBox.Visibility = Visibility.Collapsed;
                AddCollectionPanel.Visibility = Visibility.Collapsed;
                WishlistListBox.Visibility = Visibility.Collapsed;

            }
        }


        // Back Button Click - Return to Main View
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Show collection-related UI
            AddCollectionPanel.Visibility = Visibility.Visible;
            CollectionNameTextBox.Visibility = Visibility.Visible;
            CollectiondecTextBox.Visibility = Visibility.Visible;
            AddCollectionButton.Visibility = Visibility.Visible;
            CollectionsListBox.Visibility = Visibility.Visible;

            // Hide wishlist UI
            AddItemToCollectionPanel.Visibility = Visibility.Collapsed;
            wishlistwannring.Visibility = Visibility.Collapsed;
            WishlistListBox.Visibility = Visibility.Collapsed;
            AddItemToWishlistButton.Visibility = Visibility.Collapsed;
            ItemsListBox.Visibility = Visibility.Collapsed;
            WishlistListBox.Visibility = Visibility.Collapsed;
            ItemNameTextBox.Visibility = Visibility.Collapsed;
            ItemcatgoryTextBox.Visibility = Visibility.Collapsed;
            ItemdecTextBox.Visibility = Visibility.Collapsed;
            ItemseriesTextBox.Visibility = Visibility.Collapsed;
            SelectedItemDetails.Visibility = Visibility.Collapsed;
            itemname.Visibility = Visibility.Collapsed;
            BackButton.Visibility = Visibility.Collapsed;


            LoadCollections();


        }


        // View Collection Button Click
        private void ViewCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            // Show collection-related UI
            AddCollectionPanel.Visibility = Visibility.Visible;
            CollectionNameTextBox.Visibility = Visibility.Visible;
            CollectiondecTextBox.Visibility = Visibility.Visible;
            AddCollectionButton.Visibility = Visibility.Visible;
            CollectionsListBox.Visibility = Visibility.Visible;

            // Hide wishlist UI
            AddItemToCollectionPanel.Visibility = Visibility.Collapsed;
            wishlistwannring.Visibility = Visibility.Collapsed;
            WishlistListBox.Visibility = Visibility.Collapsed;
            AddItemToWishlistButton.Visibility = Visibility.Collapsed;
            ItemsListBox.Visibility = Visibility.Collapsed;
            WishlistListBox.Visibility = Visibility.Collapsed;
            ItemNameTextBox.Visibility = Visibility.Collapsed;
            ItemcatgoryTextBox.Visibility = Visibility.Collapsed;
            ItemdecTextBox.Visibility = Visibility.Collapsed;
            ItemseriesTextBox.Visibility = Visibility.Collapsed;
            SelectedItemDetails.Visibility = Visibility.Collapsed;
            itemname.Visibility = Visibility.Collapsed;
            BackButton.Visibility = Visibility.Collapsed;

            LoadCollections();
        }

        // View Wishlist Button Click
        private void ViewWishlistButton_Click(object sender, RoutedEventArgs e)
        {
            // Show wishlist-related UI
            wishlistwannring.Visibility = Visibility.Visible;
            AddItemToCollectionPanel.Visibility = Visibility.Visible;
            WishlistListBox.Visibility = Visibility.Visible;
            ItemNameTextBox.Visibility = Visibility.Visible;
            ItemcatgoryTextBox.Visibility = Visibility.Visible;
            ItemdecTextBox.Visibility = Visibility.Visible;
            ItemseriesTextBox.Visibility = Visibility.Visible;
            AddItemToWishlistButton.Visibility = Visibility.Visible;
            ItemNameTextBox.Visibility = Visibility.Visible;
            itemname.Visibility = Visibility.Visible;
            WishlistListBox.Visibility = Visibility.Visible;

            // Hide collection UI
            AddItemToCollectionPanel.Visibility = Visibility.Collapsed;
            AddCollectionPanel.Visibility = Visibility.Collapsed;
            CollectionNameTextBox.Visibility = Visibility.Collapsed;
            CollectiondecTextBox.Visibility = Visibility.Collapsed;
            AddCollectionButton.Visibility = Visibility.Collapsed;
            CollectionsListBox.Visibility = Visibility.Collapsed;
            SelectedItemDetails.Visibility = Visibility.Collapsed;
            BackButton.Visibility = Visibility.Collapsed;

            // Load wishlist items
            LoadWishlist();
        }

        // Add Collection Button Click
        private void AddCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CollectionNameTextBox.Text))
            {
                var newCollection = new Collection
                {
                    Name = CollectionNameTextBox.Text,
                    Description = CollectiondecTextBox.Text,
                    UserId = currentUserId  // Link the collection to the current user
                };

                using (var context = new CollectionContext())
                {
                    context.Collections.Add(newCollection);
                    context.SaveChanges();
                }

                CollectionNameTextBox.Clear();
                LoadCollections();
                MessageBox.Show("collection  added");

            }
            else
            {
                MessageBox.Show("Please enter a collection name.");
            }

        }

        // Load Collections from the Database
        private void LoadCollections()
        {
            using (var context = new CollectionContext())
            {
                var collections = context.Collections
                                          .Where(c => c.UserId == currentUserId)
                                          .ToList();

                CollectionsListBox.ItemsSource = collections;
            }
        }

        // Load Items for the Selected Collection
        private void LoadCollectionItems(int collectionId)
        {
            using (var context = new CollectionContext())
            {
                var collectionItems = context.CollectionItems
                                              .Where(ci => ci.CollectionId == collectionId)
                                              .Select(ci => ci.Item)  
                                              .ToList();

                ItemsListBox.ItemsSource = collectionItems;
            }
        }


        // Load Wishlist from the Database
        private void LoadWishlist()
        {
            using (var context = new CollectionContext())
            {
                var wishlistItems = context.Wishlists
                                           .Where(w => w.UserId == currentUserId)
                                           .Select(w => w.Item)
                                           .ToList();

                WishlistListBox.ItemsSource = wishlistItems;
            }
        }


        // When Collection is Selected



        // When an Item is Selected in the ItemsListBox
        private void ItemsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item selectedItem)
            {
                // Show item details
                SelectedItemDetails.Text = $"Name: {selectedItem.Name}\nSeries: {selectedItem.Series}";
                SelectedItemDetails.Visibility = Visibility.Visible;
            }
        }

        // Add Item to Collection
        private void AddItemToCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (CollectionsListBox.SelectedItem is Collection selectedCollection && !string.IsNullOrEmpty(ItemNameTextBox.Text))
            {
                var newItem = new Item
                {
                    Name = ItemNameTextBox.Text,
                    Category = ItemcatgoryTextBox.Text,
                    Description = ItemdecTextBox.Text,
                    Series = ItemseriesTextBox.Text
                };

                using (var context = new CollectionContext())
                {
                    context.Items.Add(newItem);
                    context.SaveChanges();

                    var newCollectionItem = new CollectionItem
                    {
                        CollectionId = selectedCollection.CollectionId,
                        ItemId = newItem.ItemId
                    };

                    context.CollectionItems.Add(newCollectionItem);
                    context.SaveChanges();
                }

                ItemNameTextBox.Clear();
                LoadCollectionItems(selectedCollection.CollectionId);
                MessageBox.Show("collection item added");
            }
            else
            {
                MessageBox.Show("Please select a collection and enter an item name.");
            }
        }

        private void AddItemToWishlistButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ItemNameTextBox.Text))
            {
                var newItem = new Item
                {
                    Name = ItemNameTextBox.Text,
                    Category = "Uncategorized", // Default category if not specified
                    Description = "No description provided", // Default description if not specified
                    Series = "No series assigned" // Default series if not specified
                };

                using (var context = new CollectionContext())
                {
                    context.Items.Add(newItem);
                    context.SaveChanges();

                    var newWishlistItem = new Wishlist
                    {
                        UserId = currentUserId,
                        ItemId = newItem.ItemId
                    };

                    context.Wishlists.Add(newWishlistItem);
                    context.SaveChanges();
                }

                // Clear the item name textbox and reload the wishlist
                ItemNameTextBox.Clear();
                LoadWishlist();
                MessageBox.Show("wishlist item added");

            }
            else
            {
                MessageBox.Show("Please enter an item name to add to the wishlist.");
            }
        }

    }
}