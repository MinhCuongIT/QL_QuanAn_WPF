using QL_QuanAn_3Layer_1Tier.BUS;
using QL_QuanAn_3Layer_1Tier.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QL_QuanAn_UI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private QuanAnBUS quanAnBUS = new QuanAnBUS();
        private int currID = -1;
        private DataSet currDS;
        private int indexSelected = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            QuanAn quanAn = new QuanAn() {
                Name = this.txtName.Text,
                Owner = this.txtOwner.Text,
                Address = this.txtAddress.Text,
                Phone = this.txtPhone.Text,
                IsOpen = this.tbOpen.IsChecked.HasValue && this.tbOpen.IsChecked.Value
            };
            if (this.quanAnBUS.Insert(quanAn))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearAllTextbox();
                LoadAllData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            QuanAn quanAn = new QuanAn()
            {
                Id = (int)this.currDS.Tables[0].Rows[this.indexSelected]["ID"],
                Name = this.txtName.Text,
                Owner = this.txtOwner.Text,
                Address = this.txtAddress.Text,
                Phone = this.txtPhone.Text,
                IsOpen = this.tbOpen.IsChecked.HasValue && this.tbOpen.IsChecked.Value
            };

            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (this.quanAnBUS.Delete(quanAn))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearAllTextbox();
                    LoadAllData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            QuanAn quanAn = new QuanAn()
            {
                Id = (int)this.currDS.Tables[0].Rows[this.indexSelected]["ID"],
                Name = this.txtName.Text,
                Owner = this.txtOwner.Text,
                Address = this.txtAddress.Text,
                Phone = this.txtPhone.Text,
                IsOpen = this.tbOpen.IsChecked.HasValue && this.tbOpen.IsChecked.Value
            };

            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (this.quanAnBUS.Update(quanAn))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearAllTextbox();
                    LoadAllData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ClearAllTextbox();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllData();
        }

        private void DgQuanAn_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgQuanAn.Items.IndexOf(this.dgQuanAn.CurrentItem) >= 0)
            {
                this.indexSelected = this.dgQuanAn.Items.IndexOf(this.dgQuanAn.CurrentItem);
                this.txtName.Text = this.currDS.Tables[0].Rows[this.indexSelected]["Name"].ToString();
                this.txtOwner.Text = this.currDS.Tables[0].Rows[this.indexSelected]["Owner"].ToString();
                this.txtPhone.Text = this.currDS.Tables[0].Rows[this.indexSelected]["Phone"].ToString();
                this.txtAddress.Text = this.currDS.Tables[0].Rows[this.indexSelected]["Address"].ToString();
                this.tbOpen.IsChecked = this.currDS.Tables[0].Rows[this.indexSelected]["IsOpen"].Equals(true);
            }

        }

        #region Methods
        private void ClearAllTextbox()
        {
            this.txtAddress.Clear();
            this.txtName.Clear();
            this.txtOwner.Clear();
            this.txtPhone.Clear();
            this.tbOpen.IsChecked = false;
        }
        private void LoadAllData()
        {
            this.currDS = this.quanAnBUS.LoadData();
            this.dgQuanAn.ItemsSource = this.currDS.Tables[0].DefaultView;
            this.dgQuanAn.Columns[0].Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
