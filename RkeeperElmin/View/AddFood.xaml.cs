using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Model;
using System.IO;
using Newtonsoft.Json;
using WpfApp1.ViewModel;
using System.Windows.Resources;
using Microsoft.Win32;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Window
    {
        ObservableCollection<Food> foods { get; set; }
        public ICommand add_food { get; set; }
        public ICommand browse_image { get; set; }
        public AddFood()
        {
            InitializeComponent();
            DataContext = this;
            string foods_json = File.ReadAllText("C:\\Users\\Elgun\\Source\\Repos\\McDonalds\\WpfApp1\\JSON Files\\Foods.json");
            foods = JsonConvert.DeserializeObject<ObservableCollection<Food>>(foods_json);
            food_list.ItemsSource = foods;
            add_food =new  RelayCommand(exe_add_food,canexe_add_food);
            browse_image = new RelayCommand(exe_browse,can_exe_browse);
        }
        public void exe_add_food(object? parameter) 
        {
            // Get the image path from the TextBox
            string imagePath = food_image_path.Text;

            // Verify if the path exists and the file is an image (optional, but recommended)
            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath) && IsImageFile(imagePath))
            {
                
                try
                {
                    // Specify the folder where you want to save the image
                    string targetFolderPath = @"C:\Users\Elgun\Source\Repos\McDonalds\WpfApp1\Images\FoodImages\";

                    // Get the file name from the image path
                    string fileName = System.IO.Path.GetFileName(imagePath);

                    // Create the target file path in the target folder
                    string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);

                    // Copy the image to the target folder
                    File.Copy(imagePath, targetFilePath, true);

                    // Show a success message (optional)
                    MessageBox.Show("Image saved to folder successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    
                    string imageName = System.IO.Path.GetFileName(imagePath);
                    foods.Add(new Food(food_name.Text, int.Parse(food_cost.Text), "\\Images\\FoodImages\\" + imageName));
                    string food_json=JsonConvert.SerializeObject(foods);
                    File.WriteAllText("C:\\Users\\Elgun\\Source\\Repos\\McDonalds\\WpfApp1\\JSON Files\\Foods.json", food_json);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during the image-saving process
                    MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Image path is invalid or the file is not an image
                MessageBox.Show("Invalid image path or the file is not an image.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to check if the file is an image (optional, but recommended)
        private bool IsImageFile(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp";
        }
    
        public bool canexe_add_food(object? parameter) 
        {
            if (food_name.Text != "" && food_cost.Text != "" && food_image_path.Text != "") { return true; }
            return false;
        }

        public void exe_browse(object? parameter) 
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Set the selected file's path to the TextBox
                food_image_path.Text = openFileDialog.FileName;
            }
        }
        public bool can_exe_browse(object? parameter) 
        {
            return true;
        }
    }
}
