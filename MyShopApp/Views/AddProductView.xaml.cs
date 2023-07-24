using MyShopApp.ViewModels;
using System.Windows;

namespace MyShopApp.Views
{
    public partial class AddProductView : Window
    {
        public AddProductView()
        {
            InitializeComponent();

            // Set up event handler for the OnExecuted event
            if (DataContext is AddProductVM viewModel)
            {
                viewModel.OnExecuted += OnProductSaved;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AddProductVM viewModel)
            {
                viewModel.SaveProductCommand.Execute(null);
            }
        }

        private void OnProductSaved()
        {
            // Update the product list in AdminVM after adding a new product
            if (Application.Current.MainWindow.DataContext is AdminVM adminViewModel)
            {
                adminViewModel.LoadCommand.Execute(null);
            }
        }
    }
}
