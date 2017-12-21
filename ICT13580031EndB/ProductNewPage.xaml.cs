using System;
using System.Collections.Generic;
using ICT13580031EndB.Models;
using Xamarin.Forms;

namespace ICT13580031EndB
{
    public partial class ProductNewPage : ContentPage
    {
        Product product;

        public ProductNewPage(Product product = null)
        {
            InitializeComponent();

            this.product = product;
            titleLabel.Text = product == null ? "เพิ่มสินค้าใหม่" : "แก้ไขข้อมูลสินค้า";

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            mileSlider.ValueChanged += MileSlider_ValueChanged;
            yearStepper.ValueChanged += YearStepper_ValueChanged;

            categoryPicker.Items.Add("รถยนต์นั่ง");
            categoryPicker.Items.Add("รถยนต์สมรรถนะสูง");
            categoryPicker.Items.Add("รถยนต์อเนกประสงค์ MPV");
            categoryPicker.Items.Add("รถยนต์อเนกประสงค์สมรรถนะสูง");
            categoryPicker.Items.Add("รถกระบะ");
            categoryPicker.Items.Add("รถอื่นๆ");

            brandPicker.Items.Add("BMW");
            brandPicker.Items.Add("Chevrolet");
            brandPicker.Items.Add("Ford");
            brandPicker.Items.Add("Honda");
            brandPicker.Items.Add("Hyudai");
            brandPicker.Items.Add("MG");
            brandPicker.Items.Add("Mazda");
            brandPicker.Items.Add("Mercades Benz");
            brandPicker.Items.Add("Mitsubishi");
            brandPicker.Items.Add("Nissan");
            brandPicker.Items.Add("Peugeot");
            brandPicker.Items.Add("Suzuki");
            brandPicker.Items.Add("Toyota");
            brandPicker.Items.Add("Volvo");

			if (product != null)
			{
				nameEntry.Text = product.Name;
				categoryPicker.SelectedItem = product.Category;
                brandPicker.SelectedItem = product.Brand;
                generationEntry.Text = product.Generation;
                colorPicker.SelectedItem = product.Color;
                descriptionEditor.Text = product.Description;
                priceEntry.Text = product.Price.ToString();
                provincePicker.SelectedItem = product.Province;
                telephoneEntry.Text = product.TelephoneNumber;
			
			}

        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุรต้องการบันทึก ใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOk)
			{
				if (product == null)
				{
					product = new Product();
					product.Name = nameEntry.Text;
					product.Category = categoryPicker.SelectedItem.ToString();
                    product.Brand = brandPicker.SelectedItem.ToString();
                    product.Generation = generationEntry.Text;
                    product.Color = colorPicker.SelectedItem.ToString();
                    product.Description = descriptionEditor.Text;
                    product.Price = decimal.Parse(priceEntry.Text);
                    product.Province = provincePicker.SelectedItem.ToString();
					product.TelephoneNumber = telephoneEntry.ToString();

					
                    var id = App.DbHelper.AddProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
				}
				else
				{
					product.Name = nameEntry.Text;
					product.Category = categoryPicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Generation = generationEntry.Text;
					product.Color = colorPicker.SelectedItem.ToString();
					product.Description = descriptionEditor.Text;
					product.Price = decimal.Parse(priceEntry.Text);
					product.Province = provincePicker.SelectedItem.ToString();

					var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย", "ตกลง");
				}
				await Navigation.PopModalAsync();
			}

        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void MileSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
			int value = (int)e.NewValue;
            mileLabel.Text = value.ToString();


		}

        void YearStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            yearLabel.Text = value.ToString();
        }
    }
}
