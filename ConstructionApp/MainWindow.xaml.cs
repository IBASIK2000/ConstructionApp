using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ConstructionApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataGridObjects.ItemsSource = ConstructionDB.GetContext().Construction_objects.OrderBy(x => x.object_id).ToList();
                DataGridContractors.ItemsSource = ConstructionDB.GetContext().Contractors.OrderBy(x => x.contractor_id).ToList();
                DataGridContracts.ItemsSource = ConstructionDB.GetContext().Contracts.OrderBy(x => x.contract_id).ToList();
                DataGridStages.ItemsSource = ConstructionDB.GetContext().Construction_stages.OrderBy(x => x.stage_id).ToList();
                DataGridObjectMaterials.ItemsSource =ConstructionDB.GetContext().Object_materials.OrderBy(x => x.object_material_id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            new AddEditObjectWindow(null).ShowDialog();
            LoadData();
        }

        private void EditObject_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Construction_objects selectedObject)
            {
                new AddEditObjectWindow(selectedObject).ShowDialog();
                LoadData();
            }
        }

        private void DeleteObject_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Construction_objects selectedObject)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить объект?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConstructionDB.GetContext().Construction_objects.Remove(selectedObject);
                        ConstructionDB.GetContext().SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void AddContractor_Click(object sender, RoutedEventArgs e)
        {
            new AddEditContractorWindow(null).ShowDialog();
            LoadData();
        }

        private void EditContractor_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Contractors selectedContractor)
            {
                new AddEditContractorWindow(selectedContractor).ShowDialog();
                LoadData();
            }
        }

        private void DeleteContractor_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Contractors selectedContractor)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить подрядчика?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConstructionDB.GetContext().Contractors.Remove(selectedContractor);
                        ConstructionDB.GetContext().SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            new AddEditContractWindow(null).ShowDialog();
            LoadData();
        }

        private void EditContract_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Contracts selectedContract)
            {
                new AddEditContractWindow(selectedContract).ShowDialog();
                LoadData();
            }
        }

        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Contracts selectedContract)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить контракт?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConstructionDB.GetContext().Contracts.Remove(selectedContract);
                        ConstructionDB.GetContext().SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void AddStage_Click(object sender, RoutedEventArgs e)
        {
            new AddEditStageWindow(null).ShowDialog();
            LoadData();
        }

        private void EditStage_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Construction_stages selectedStage)
            {
                new AddEditStageWindow(selectedStage).ShowDialog();
                LoadData();
            }
        }

        private void DeleteStage_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Construction_stages selectedStage)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этап?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConstructionDB.GetContext().Construction_stages.Remove(selectedStage);
                        ConstructionDB.GetContext().SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void AddObjectMaterial_Click(object sender, RoutedEventArgs e)
        {
            new AddEditObjectMaterialWindow(null).ShowDialog();
            LoadData();
        }

        private void EditObjectMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Object_materials selectedObjectMaterial)
            {
                new AddEditObjectMaterialWindow(selectedObjectMaterial).ShowDialog();
                LoadData();
            }
        }

        private void DeleteObjectMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Object_materials selectedObjectMaterial)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить материал?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ConstructionDB.GetContext().Object_materials.Remove(selectedObjectMaterial);
                        ConstructionDB.GetContext().SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}