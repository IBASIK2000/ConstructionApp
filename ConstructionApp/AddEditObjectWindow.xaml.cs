using System;
using System.Windows;
using System.Windows.Controls;

namespace ConstructionApp
{
    public partial class AddEditObjectWindow : Window
    {
        private Construction_objects _currentObject;

        public AddEditObjectWindow(Construction_objects selectedObject)
        {
            InitializeComponent();
            _currentObject = selectedObject ?? new Construction_objects();
            DataContext = _currentObject;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxAddress.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxConstructionStatus.Text) || string.IsNullOrWhiteSpace(TextBoxStatus.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (_currentObject.object_id == 0)
                {
                    ConstructionDB.GetContext().Construction_objects.Add(_currentObject);
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
    }
}