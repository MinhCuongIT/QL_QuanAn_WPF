using QL_QuanAn_3Layer_1Tier.DAO;
using QL_QuanAn_3Layer_1Tier.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanAn_3Layer_1Tier.BUS
{
    public class QuanAnBUS
    {
        QuanAnDAO quanAnDAO = new QuanAnDAO();

        /// <summary>
        /// Tải dữ liệu từ DB
        /// </summary>
        /// <returns>Dataset chứa dữ liệu tải được</returns>
        public DataSet LoadData()
        {
            return quanAnDAO.LoadData();
        }

        /// <summary>
        /// Thực hiện thêm một quán ăn trong database
        /// </summary>
        /// <param name="quanAn">Quán ăn cần thêm</param>
        /// <returns>true nếu thành công, ngược lại</returns>
        public bool Insert(QuanAn quanAn)
        {
            if (Valid(quanAn.Name) || Valid(quanAn.Owner) || Valid(quanAn.Address) || Valid(quanAn.Phone))
            {
                return false;
            }
            if (quanAnDAO.IsExisted(quanAn.Id))
            {
                return false;
            }
            return quanAnDAO.Insert(quanAn);
        }

        /// <summary>
        /// Thực hiện cập nhật một quán ăn trong database
        /// </summary>
        /// <param name="quanAn">Quán ăn cần cập nhật</param>
        /// <returns>true nếu thành công, ngược lại</returns>
        public bool Update(QuanAn quanAn)
        {
            if (Valid(quanAn.Name) || Valid(quanAn.Owner) || Valid(quanAn.Address) || Valid(quanAn.Phone))
            {
                return false;
            }
            if (!quanAnDAO.IsExisted(quanAn.Id))
            {
                return false;
            }
            return quanAnDAO.Update(quanAn);
        }

        /// <summary>
        /// Thực hiện xóa một quán ăn trong database
        /// </summary>
        /// <param name="quanAn">Quán ăn cần xóa</param>
        /// <returns>true nếu thành công, ngược lại</returns>
        public bool Delete(QuanAn quanAn)
        {
            if (Valid(quanAn.Name) || Valid(quanAn.Owner) || Valid(quanAn.Address) || Valid(quanAn.Phone))
            {
                return false;
            }
            if (!quanAnDAO.IsExisted(quanAn.Id))
            {
                return false;
            }
            return quanAnDAO.Delete(quanAn);
        }

        /// <summary>
        /// Kiểm tra một quán ăn có tồn tại trong hệ thống hay chưa
        /// </summary>
        /// <param name="maQuanAn">Mã Quán Ăn</param>
        /// <returns>true nếu tồn tại, ngược lại</returns>
        public bool IsExisted(int maQuanAn)
        {
            return quanAnDAO.IsExisted(maQuanAn);
        }

        #region Methods
        /// <summary>
        /// Kiểm tra một chuỗi hợp lệ
        /// </summary>
        /// <param name="str">Chuỗi bất kì</param>
        /// <returns>true nếu hợp lệ, ngược lại</returns>
        private bool Valid(string str)
        {
            return string.IsNullOrEmpty(str);
        }
        #endregion
    }
}
