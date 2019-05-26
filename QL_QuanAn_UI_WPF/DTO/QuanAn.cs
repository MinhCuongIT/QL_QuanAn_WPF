using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanAn_3Layer_1Tier.DTO
{
    public class QuanAn
    {
        /// <summary>
        /// Mã quán ăn
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tên quán ăn
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Chủ sở hữu quán ăn
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Địa chỉ quán ăn
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại quán ăn
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Quán có mở cửa hay không
        /// </summary>
        public bool IsOpen { get; set; }
    }
}
