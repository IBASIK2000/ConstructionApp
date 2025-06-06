using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConstructionApp
{
    public partial class AddEditObjectMaterialWindow : Window
    {
        private Object_materials _currentObjectMaterial;

        public AddEditObjectMaterialWindow(Object_materials selectedObjectMaterial)
        {
            InitializeComponent();
            _currentObjectMaterial = selectedObjectMaterial ?? new Object_materials();
            DataContext = _currentObjectMaterial;

            ComboBoxObject.ItemsSource = ConstructionDB.GetContext().Construction_objects.ToList();
            ComboBoxMaterial.ItemsSource = ConstructionDB.GetContext().Materials.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxObject.SelectedItem == null || ComboBoxMaterial.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(TextBoxQuantity.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Проверка корректности количества
                if (!decimal.TryParse(TextBoxQuantity.Text, out decimal quantity) || quantity <= 0)
                {
                    MessageBox.Show("Введите корректное количество (положительное число)!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var context = ConstructionDB.GetContext();
                if (_currentObjectMaterial.object_material_id == 0)
                {
                    context.Object_materials.Add(_currentObjectMaterial);
                }

                context.SaveChanges();
                MessageBox.Show("Материал сохранён успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void TextBoxQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Разрешаем только цифры и точку для десятичных чисел
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true;
            }
            // Запрещаем ввод более одной точки
            if (e.Text == "." && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}