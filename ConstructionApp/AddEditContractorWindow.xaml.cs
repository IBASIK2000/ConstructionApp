using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConstructionApp
{
    public partial class AddEditContractorWindow : Window
    {
        private Contractors _currentContractor;

        public AddEditContractorWindow(Contractors selectedContractor)
        {
            InitializeComponent();
            _currentContractor = selectedContractor ?? new Contractors();
            DataContext = _currentContractor;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxInn.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxContactPerson.Text) || string.IsNullOrWhiteSpace(TextBoxPhone.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxEmail.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!Regex.IsMatch(TextBoxEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Некорректный email!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (_currentContractor.contractor_id == 0)
                {
                    ConstructionDB.GetContext().Contractors.Add(_currentContractor);
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
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}