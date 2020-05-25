/*----------------------------------------------------------------
// Copyright (C) 江苏秀园果科技有限公司
// 版权所有。
//
// 文件名：ShelfOnInfo.cs
// 功能描述：创建上架单时从数据库读取到的货物信息和货架信息
// 
// 创建标识：zhangning   2020/5/18 17:37:22  
// 
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDSmartWarehouse
{
    public class ShelfOnInfo
    {
        public List<Productinfo> productinfos = new List<Productinfo>();

        public List<ShelfCode> ShelfCodes = new List<ShelfCode>();
    }

    public class ShelfOffInfo
    {
        public Dictionary<string, List<ShelfCode>> productinfos = new Dictionary<string, List<ShelfCode>>();

       
    }

    public class Productinfo
    {
        public string ProductName { get; set; }

        public string Count { get; set; }

        public List<string> tids { get; set; }
    }

    public class ShelfCode
    {
        public string shelfcode { get; set;  }

        public string shelflocation { get; set; }

        public List<string> tids { get; set; }
    }

    public class ShelfOnAndOffOrderInfo
    {
        public string ordernum { get; set; }

        public DateTime createtime { get; set; }

        public string operato { get; set; }

        public DateTime shelfontime { get; set; }

        public string productname { get; set; }

        public string count { get; set; }

        public string orderstate { get; set; }

    }


}
