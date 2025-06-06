using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ConstructionApp
{
    public partial class AddEditStageWindow : Window
    {
        private Construction_stages _currentStage;

        public AddEditStageWindow(Construction_stages selectedStage)
        {
            InitializeComponent();
            _currentStage = selectedStage ?? new Construction_stages();
            DataContext = _currentStage;

            ComboBoxObject.ItemsSource = ConstructionDB.GetContext().Construction_objects.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxObject.SelectedItem == null || string.IsNullOrWhiteSpace(TextBoxName.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxStatus.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (_currentStage.stage_id == 0)
                {
                    ConstructionDB.GetContext().Construction_stages.Add(_currentStage);
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