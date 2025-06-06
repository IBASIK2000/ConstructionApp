using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConstructionApp
{
    public partial class AddEditContractWindow : Window
    {
        private Contracts _currentContract;

        public AddEditContractWindow(Contracts selectedContract)
        {
            InitializeComponent();
            _currentContract = selectedContract ?? new Contracts();
            DataContext = _currentContract;

            ComboBoxObject.ItemsSource = ConstructionDB.GetContext().Construction_objects.ToList();
            ComboBoxContractor.ItemsSource = ConstructionDB.GetContext().Contractors.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxObject.SelectedItem == null || ComboBoxContractor.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(TextBoxAmount.Text) || string.IsNullOrWhiteSpace(TextBoxNumber.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (_currentContract.contract_id == 0)
                {
                    ConstructionDB.GetContext().Contracts.Add(_currentContract);
                }

                ConstructionDB.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true;
            }
        }
    }
}