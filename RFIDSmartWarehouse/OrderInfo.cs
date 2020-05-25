/*----------------------------------------------------------------
// Copyright (C) 江苏秀园果科技有限公司
// 版权所有。
//
// 文件名：OrderInfo.cs
// 功能描述：
// 
// 创建标识：zhangning   2020/5/13 10:08:53  
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
    public class OrderInfo
    {
        public class InHouse
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            public string 入库订单编号 { get; set; }

            /// <summary>
            /// 操作人
            /// </summary>
            public string 入库操作人 { get; set; }

            /// <summary>
            /// 出入库时间
            /// </summary>
            public DateTime 入库时间 { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime 入库创建时间 { get; set; }

            /// <summary>
            /// 产品名称
            /// </summary>
            public string 入库产品名称 { get; set; }

            /// <summary>
            /// 产品数量
            /// </summary>
            public int 入库产品数量 { get; set; }

            /// <summary>
            /// 订单状态
            /// </summary>
            public string 入库订单状态 { get; set; }
        }

        public class OutHouse
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            public string 出库订单编号 { get; set; }

            /// <summary>
            /// 操作人
            /// </summary>
            public string 出库操作人 { get; set; }

            /// <summary>
            /// 出入库时间
            /// </summary>
            public DateTime 出库时间 { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime 出库创建时间 { get; set; }

            /// <summary>
            /// 产品名称
            /// </summary>
            public string 出库产品名称 { get; set; }

            /// <summary>
            /// 产品数量
            /// </summary>
            public int 出库产品数量 { get; set; }

            /// <summary>
            /// 订单状态
            /// true:已出库\入库
            /// false:未入库\出库
            /// </summary>
            public string 出库订单状态 { get; set; }
        }
    }
}
