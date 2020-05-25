/*----------------------------------------------------------------
// Copyright (C) 江苏秀园果科技有限公司
// 版权所有。
//
// 文件名：ShelfCodeProductInfo.cs
// 功能描述：新增盘点订单时获取需要的产品信息
// 
// 创建标识：zhangning   2020/5/22 10:08:54  
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
    public class ShelfCodeProductInfo
    {
        public string productname { get; set; }

        public List<string> shelflocation { get; set; }

    }
}
