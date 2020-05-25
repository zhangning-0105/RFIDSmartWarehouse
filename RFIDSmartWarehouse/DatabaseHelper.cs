/*----------------------------------------------------------------
// Copyright (C) 江苏秀园果科技有限公司
// 版权所有。
//
// 文件名：DatabaseHelper.cs
// 功能描述：
// 
// 创建标识：zhangning   2020/5/14 11:39:52  
// 
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using HZH_Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDSmartWarehouse
{
    public class DatabaseHelper
    {
        public static string constr = "server=192.168.160.100;port=3366;user=root;password=root; database=RFIDSmartWarehouse;Charset=utf8";

       public static MySqlConnection myCon = new MySqlConnection(constr);

        public static bool CreateWarehoueOrder(string productname, string quantity)
        {
            try
            {
                myCon.Open();
                string sql1 = string.Format("INSERT INTO WarehoueOrder (OrderNumber,ProductName,CreateTime,Quantity,OrderStatus) VALUES('{0}','{1}','{2}','{3}','未入库')", Guid.NewGuid().ToString("N"), productname, DateTime.Now.ToString(), quantity);

                MySqlCommand mySqlCommand1 = new MySqlCommand(sql1, myCon);
                int result1 = mySqlCommand1.ExecuteNonQuery();
                if (result1 != 1)
                {

                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("创建入库订单出错", ex);
                return false;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static bool CreateOuthoueOrder(string productname, string quantity)
        {
            try
            {
                myCon.Open();
                string sql1 = string.Format("INSERT INTO OuthoueOrder (OrderNumber,ProductName,CreateTime,Quantity,OrderStatus) VALUES('{0}','{1}','{2}','{3}','未出库')", Guid.NewGuid().ToString("N"), productname, DateTime.Now.ToString(), quantity);
                MySqlCommand mySqlCommand1 = new MySqlCommand(sql1, myCon);
                int result1 = mySqlCommand1.ExecuteNonQuery();
                if (result1 != 1)
                {

                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("创建入库订单出错", ex);
                return false;
            }
            finally
            {
                myCon.Close();
            }
        }

        /// <summary>
        /// 获取所有已下架的商品信息，用于创建出库单
        /// </summary>
        /// <returns></returns>
        public static List<Productinfo> GetProductinfos()
        {
            try
            {
                myCon.Open();
                string sql = "SELECT sp.ProductName,COUNT(1),GROUP_CONCAT(tid) FROM StockProducts sp WHERE sp.ProductState='已下架' GROUP BY sp.ProductName ";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<Productinfo> productinfos = new List<Productinfo>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        Productinfo productinfo = new Productinfo
                        {
                            ProductName = mySqlDataReader[0].ToString(),
                            tids = mySqlDataReader[2].ToString().Split(new char[1] { ',' }).ToList(),
                            Count = mySqlDataReader[1].ToString()
                        };
                        productinfos.Add(productinfo);
                    }
                }
                mySqlDataReader.Close();
                return productinfos;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static List<object[]> GetStockProductInfos()
        {
            try
            {
                myCon.Open();
                string sql = "SELECT * FROM StockProducts ";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<object[]> list = new List<object[]>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                       object[] row=
                       {
                          mySqlDataReader[0].ToString(),
                          mySqlDataReader[1].ToString(),
                          mySqlDataReader[2].ToString(),
                          mySqlDataReader[5].ToString(),
                          mySqlDataReader[3].ToString(),
                          mySqlDataReader[4].ToString(),
                       };
                        list.Add(row);
                    }
                }
                mySqlDataReader.Close();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static List<string> GetProductNames()
        {
            try
            {
                myCon.Open();
                string sql = "	SELECT sp.ProductName,COUNT(1) FROM StockProducts sp  GROUP BY sp.ProductName ";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<string> list = new List<string>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        var productname = mySqlDataReader[0].ToString();
  
                        list.Add(productname);
                    }
                }
                mySqlDataReader.Close();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }


        /// <summary>
        /// 获取入库订单
        /// </summary>
        /// <returns></returns>
        public static List<object[]> GetInHouseOrders()
        {
            try
            {
                string sql = "SELECT * FROM WarehoueOrder ";
                myCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<object[]> orderlist = new List<object[]>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        object[] row =
                        {   mySqlDataReader[0].ToString(),
                            mySqlDataReader[4].ToString(),
                            mySqlDataReader[1].ToString(),
                            mySqlDataReader[5].ToString(),
                            mySqlDataReader[2].ToString() ,
                            mySqlDataReader[3].ToString(),
                            mySqlDataReader[6].ToString()
                        };
                        orderlist.Add(row);
                    }
                }
                mySqlDataReader.Close();

                return orderlist;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询数据库出错", ex);
                return new List<object[]>();
            }
            finally
            {
                myCon.Close();
            }
        }

        /// <summary>
        /// 获取盘点订单信息
        /// </summary>
        /// <returns></returns>
        public static List<object[]> GetInventoryInfos()
        {
            try
            {
                string sql = "SELECT * FROM InventoryInfo ";
                myCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<object[]> orderlist = new List<object[]>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        object[] row =
                        {   mySqlDataReader[0].ToString(),
                            mySqlDataReader[2].ToString(),
                            mySqlDataReader[3].ToString(),
                            mySqlDataReader[9].ToString(),
                            mySqlDataReader[4].ToString() ,
                            mySqlDataReader[1].ToString(),
                            mySqlDataReader[6].ToString(),
                            mySqlDataReader[8].ToString(),
                            mySqlDataReader[10].ToString()
                        };
                        orderlist.Add(row);
                    }
                }
                mySqlDataReader.Close();

                return orderlist;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询数据库出错", ex);
                return new List<object[]>();
            }
            finally
            {
                myCon.Close();
            }
        }


        public static List<ShelfCodeProductInfo> GetShelfCodeProductInfos()
        {
            try
            {
                string sql = "SELECT    ProductName,	COUNT(1),	GROUP_CONCAT(ShelfLocation) FROM ShelfCodePositionCorrespondence WHERE    ShelfState = '已上架'GROUP BY ProductName ";
                myCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<ShelfCodeProductInfo> orderlist = new List<ShelfCodeProductInfo>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        ShelfCodeProductInfo  shelfCodeProductInfo  = new ShelfCodeProductInfo
                        { 
                           productname= mySqlDataReader[0].ToString(),
                           shelflocation= mySqlDataReader[2].ToString().Split(new char[1] { ','}).ToList(),
              
                        };
                        orderlist.Add(shelfCodeProductInfo);
                    }
                }
                mySqlDataReader.Close();

                return orderlist;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询数据库出错", ex);
                return new List<ShelfCodeProductInfo>();
            }
            finally
            {
                myCon.Close();
            }
        }





        /// <summary>
        /// 新增盘点订单
        /// </summary>
        /// <param name="productname"></param>
        /// <param name="tids"></param>
        /// <param name="shelfLocation"></param>
        /// <param name="shelfcode"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool InsertIntoInventoryInfo(string productname,string shelfLocation)
        {
            try
            {
                myCon.Open();
                string tids = "";
                string shelfcode = "";
                string sql1 = string.Format(" SELECT tids ,shelfcode FROM ShelfCodePositionCorrespondence WHERE ProductName='{0}' and shelfLocation='{1}'", productname, shelfLocation);
                MySqlCommand mySqlCommand = new MySqlCommand(sql1, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<object[]> orderlist = new List<object[]>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        tids = mySqlDataReader[0].ToString();
                        shelfcode = mySqlDataReader[1].ToString();
                    }
                }
                mySqlDataReader.Close();
                int count = tids.Split(new char[1] { ',' }).ToList().Count();
                string sql2 = string.Format("INSERT INTO InventoryInfo (ordernum,createtime,productname,tids,shelfLocation,shelfcode,count,orderstate) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','未盘点')",
                Guid.NewGuid().ToString("N"), DateTime.Now.ToString(), productname, tids, shelfLocation, shelfcode, count);
                MySqlCommand mySqlCommand1 = new MySqlCommand(sql2, myCon);
                int result1 = mySqlCommand1.ExecuteNonQuery();
                if (result1 != 1)
                {
                   
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("插入数据库出错", ex);
                

                return false;
            }
            finally
            {
                myCon.Close();
            }
        }

        /// <summary>
        /// 向库存表中插入产品信息
        /// 更新入库订单状态
        /// </summary>
        /// <param name="tids"></param>
        /// <param name="productname"></param>
        /// <returns></returns>
        public static bool InsertIntoProdcutsAndUpdateWarehouseOrderstaus(List<string> tids,string productname, string ordernum)
        {
            myCon.Open();
            MySqlTransaction transaction = myCon.BeginTransaction();
            try
            {
                foreach (var item in tids)
                {
                    string sql1 = string.Format("INSERT INTO StockProducts (Tid,ProductName,StorageTime,ProductState) VALUES('{0}','{1}','{2}','已入库')", item, productname, DateTime.Now.ToString());

                    MySqlCommand mySqlCommand1 = new MySqlCommand(sql1, myCon);
                    int result1 = mySqlCommand1.ExecuteNonQuery();
                    if (result1 != 1)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                string sql2 = string.Format("UPDATE WarehoueOrder set OrderStatus='已入库',StorageTime='{1}' WHERE OrderNumber='{0}'", ordernum, DateTime.Now.ToString());
                MySqlCommand mySqlCommand2 = new MySqlCommand(sql2, myCon);
                int result2 = mySqlCommand2.ExecuteNonQuery();
                if (result2 != 1)
                {
                    transaction.Rollback();

                    return false;
                }
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("插入数据库出错", ex);
                transaction.Rollback();

                return false;
            }
            finally
            {
                myCon.Close();
            }
        }


        /// <summary>
        /// 获取出库订单信息
        /// </summary>
        /// <returns></returns>
        public static List<object[]> GetOutHouseOrders()
        {
            try
            {
                string sql = "SELECT * FROM OuthoueOrder ";
                myCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<object[]> orderlist = new List<object[]>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        object[] row =
                        {   mySqlDataReader[0].ToString(),
                            mySqlDataReader[4].ToString(),
                            mySqlDataReader[1].ToString(),
                            mySqlDataReader[5].ToString(),
                            mySqlDataReader[2].ToString() ,
                            mySqlDataReader[3].ToString(),
                            mySqlDataReader[6].ToString()
                        };
                        orderlist.Add(row);
                    }
                }
                mySqlDataReader.Close();

                return orderlist;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询数据库出错", ex);
                return new List<object[]>();
            }
            finally
            {
                myCon.Close();
            }
        }

        /// <summary>
        /// 更新产品出库信息
        /// 更新出库订单状态
        /// </summary>
        /// <param name="tids"></param>
        /// <param name="productname"></param>
        /// <param name="ordernum"></param>
        /// <returns></returns>
        public static bool QueryProdcutsAndUpdateOuthouseOrderstaus(List<string> tids, string productname, string ordernum)
        {
            myCon.Open();
            MySqlTransaction transaction = myCon.BeginTransaction();
            try
            {
                foreach (var item in tids)
                {
                    string sql = string.Format("SELECT ProductName from StockProducts where tid='{0}'", item);
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        if (mySqlDataReader.HasRows)
                        {
                            if (productname != mySqlDataReader[0].ToString())
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    mySqlDataReader.Close();

                    string sql1 = string.Format("UPDATE  StockProducts set ProductState='已出库',OuthouseTime='{1}' where tid= '{0}' and ProductState='已下架'", item,DateTime.Now.ToString());
                    MySqlCommand mySqlCommand1 = new MySqlCommand(sql1, myCon);
                    int result1 = mySqlCommand1.ExecuteNonQuery();
                    if (result1 != 1)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                string sql2 = string.Format("UPDATE OuthoueOrder set OrderStatus='已出库',OuthouseTime='{1}' WHERE OrderNumber='{0}'", ordernum, DateTime.Now.ToString());
                MySqlCommand mySqlCommand2 = new MySqlCommand(sql2, myCon);
                int result2 = mySqlCommand2.ExecuteNonQuery();
                if (result2 != 1)
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("插入数据库出错", ex);
                transaction.Rollback();
                return false;
            }
            finally
            {
                myCon.Close();
            }
        }


        public static ShelfOnInfo GetShelfOnInfo()
        {
            try
            {
                myCon.Open();
                string sql = "SELECT sp.ProductName,GROUP_CONCAT(tid),COUNT(1) FROM StockProducts sp WHERE sp.ProductState='已入库' GROUP BY sp.ProductName ";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                ShelfOnInfo shelfOnInfo = new ShelfOnInfo();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        Productinfo productinfo = new Productinfo
                        {
                            ProductName = mySqlDataReader[0].ToString(),
                            tids = mySqlDataReader[1].ToString().Split(new char[1] { ','}).ToList(),
                            Count= mySqlDataReader[2].ToString()
                        };
                        shelfOnInfo.productinfos.Add(productinfo);
                    }
                }
                mySqlDataReader.Close();
                string sql2 = "SELECT shelfcode,shelflocation from ShelfCodePositionCorrespondence WHERE ShelfState='无货物'";
                MySqlCommand mySqlCommand2 = new MySqlCommand(sql2, myCon);
                MySqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                while (mySqlDataReader2.Read())
                {
                    if (mySqlDataReader2.HasRows)
                    {
                        ShelfCode shelfCode = new ShelfCode
                        {
                            shelfcode = mySqlDataReader2[0].ToString(),
                            shelflocation = mySqlDataReader2[1].ToString(),
                        };
                        shelfOnInfo.ShelfCodes.Add(shelfCode);
                    }
                }
                mySqlDataReader2.Close();
                return shelfOnInfo;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询失败", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static List<Productinfo> GetShelfOffInfo()
        {
            try
            {
                myCon.Open();
                string sql = "SELECT ProductName FROM ShelfCodePositionCorrespondence  WHERE ShelfState='已上架' group by ProductName ";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<Productinfo> productinfos = new List<Productinfo>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        Productinfo productinfo = new Productinfo
                        {
                            ProductName = mySqlDataReader[0].ToString(),
                   
                        };
                       productinfos.Add(productinfo);
                    }
                }
                mySqlDataReader.Close();
           
                return productinfos;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询失败", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static List<ShelfCode> GetShelfCodes(string productname)
        {
            try
            {
                myCon.Open();
                string sql2 = string.Format("SELECT shelfcode,shelflocation,Tids from ShelfCodePositionCorrespondence WHERE ShelfState='已上架' and productname='{0}'", productname);
                MySqlCommand mySqlCommand2 = new MySqlCommand(sql2, myCon);
                MySqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                List<ShelfCode> shelfCodes = new List<ShelfCode>();
                while (mySqlDataReader2.Read())
                {
                    if (mySqlDataReader2.HasRows)
                    {
                        ShelfCode shelfCode = new ShelfCode
                        {
                            shelfcode = mySqlDataReader2[0].ToString(),
                            shelflocation = mySqlDataReader2[1].ToString(),
                            tids= mySqlDataReader2[2].ToString().Split(new char[1] { ','}).ToList()
                        };
                        shelfCodes.Add(shelfCode);
                    }
                }
                mySqlDataReader2.Close();
                return shelfCodes;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询失败", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }


        public static bool CreateShelfOnOrderInfoAndUpdateShelfState(string ordernum, List<string> tids, string shelfLocation, string shelfcode,string productname,string count)
        {
            myCon.Open();
            MySqlTransaction transaction = myCon.BeginTransaction();
            try
            {

                string sql1 = string.Format("INSERT INTO ShelfOnOrderInfo (ordernum,tids,shelfLocation,shelfcode,orderstate,createtime,productname,count, remark) VALUES('{0}','{1}','{2}','{3}','未上架','{4}','{5}','{6}','0')", ordernum, string.Join(",", tids.ToArray()), shelfLocation, shelfcode,DateTime.Now.ToString(), productname, count); ;

                MySqlCommand mySqlCommand1 = new MySqlCommand(sql1, myCon);
                int result1 = mySqlCommand1.ExecuteNonQuery();
                if (result1 != 1)
                {
                    transaction.Rollback();
                    return false;
                }
                string sql2 = string.Format("UPDATE ShelfCodePositionCorrespondence SET ShelfState='未上架',tids='{1}' WHERE shelfcode='{0}'", shelfcode, string.Join(",", tids.ToArray()));
                MySqlCommand mySqlCommand2 = new MySqlCommand(sql2, myCon);
                int result2 = mySqlCommand2.ExecuteNonQuery();
                if (result2 != 1)
                {
                    transaction.Rollback();
                    return false;
                }
                foreach (var item in tids)
                {
                    string sql3 = string.Format("UPDATE StockProducts sp SET  ProductState='未上架' WHERE tid='{0}'", item);
                    MySqlCommand mySqlCommand3 = new MySqlCommand(sql3, myCon);
                    if (mySqlCommand3.ExecuteNonQuery() != 1)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                transaction.Commit();

                return true;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("创建上架订单失败", ex);
                return false;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static bool CreateShelfOffOrderInfoAndUpdateShelfState(string ordernum, List<string> tids, string shelfLocation, string shelfcode, string productname, string count)
        {
            myCon.Open();
            MySqlTransaction transaction = myCon.BeginTransaction();
            try
            {

                string sql1 = string.Format("INSERT INTO ShelfOffOrderInfo (ordernum,tids,shelfLocation,shelfcode,orderstate,createtime,productname,count, remark) VALUES('{0}','{1}','{2}','{3}','未下架','{4}','{5}','{6}','1')", ordernum, string.Join(",", tids.ToArray()), shelfLocation, shelfcode, DateTime.Now.ToString(), productname, count); ;

                MySqlCommand mySqlCommand1 = new MySqlCommand(sql1, myCon);
                int result1 = mySqlCommand1.ExecuteNonQuery();
                if (result1 != 1)
                {
                    transaction.Rollback();
                    return false;
                }
                string sql2 = string.Format("UPDATE ShelfCodePositionCorrespondence SET ShelfState='未下架' WHERE shelfcode='{0}'", shelfcode);
                MySqlCommand mySqlCommand2 = new MySqlCommand(sql2, myCon);
                int result2 = mySqlCommand2.ExecuteNonQuery();
                if (result2 != 1)
                {
                    transaction.Rollback();
                    return false;
                }
                foreach (var item in tids)
                {
                    string sql3 = string.Format("UPDATE StockProducts sp SET  ProductState='未下架' WHERE tid='{0}'", item);
                    MySqlCommand mySqlCommand3 = new MySqlCommand(sql3, myCon);
                    if (mySqlCommand3.ExecuteNonQuery() != 1)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                transaction.Commit();

                return true;

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("创建上架订单失败", ex);
                return false;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static List<object[]> GetShelfOnOrderInfos()
        {
            try
            {
                myCon.Open();
                string sql = "SELECT * from ShelfOnOrderInfo";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<object[]> list = new List<object[]>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        object[] row =
                        {
                          mySqlDataReader[0].ToString(),
                          mySqlDataReader[2].ToString(),
                          mySqlDataReader[3].ToString(),
                          mySqlDataReader[9].ToString(),
                          mySqlDataReader[4].ToString(),
                          mySqlDataReader[1].ToString(),
                          mySqlDataReader[8].ToString(),
                        };
                        list.Add(row);
                    }
                }
                mySqlDataReader.Close();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询上架订单失败", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static List<object[]> GetShelfOffOrderInfos()
        {
            try
            {
                myCon.Open();
                string sql = "SELECT * from ShelfOffOrderInfo";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, myCon);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                List<object[]> list = new List<object[]>();
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        object[] row =
                        {
                          mySqlDataReader[0].ToString(),
                          mySqlDataReader[2].ToString(),
                          mySqlDataReader[3].ToString(),
                          mySqlDataReader[9].ToString(),
                          mySqlDataReader[4].ToString(),
                          mySqlDataReader[1].ToString(),
                          mySqlDataReader[8].ToString(),
                        };
                        list.Add(row);
                    }
                }
                mySqlDataReader.Close();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询上架订单失败", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }

        public static List<Productinfo> GetReportProductinfos(string productname,DateTime begintime,DateTime endtime)
        {
            try
            {
                myCon.Open();
                string sql1, sql2, sql3, sql4, sql5, sql6;
                if (begintime == null)
                {
                    sql1 = string.Format("SELECT sp.ProductName,COUNT(1),GROUP_CONCAT(tid) FROM StockProducts sp WHERE sp.ProductState='已入库'  and sp.ProductName=''{0} GROUP BY sp.ProductName ", productname);
                    sql2 = string.Format("SELECT sp.ProductName,COUNT(1),GROUP_CONCAT(tid) FROM StockProducts sp WHERE sp.ProductState='未上架'  and sp.ProductName=''{0} GROUP BY sp.ProductName ", productname);
                    sql3 = string.Format("SELECT sp.ProductName,COUNT(1),GROUP_CONCAT(tid) FROM StockProducts sp WHERE sp.ProductState='已上架'  and sp.ProductName=''{0} GROUP BY sp.ProductName ", productname);
                    sql4 =string.Format("SELECT sp.ProductName,COUNT(1),GROUP_CONCAT(tid) FROM StockProducts sp WHERE sp.ProductState='未下架'  and sp.ProductName=''{0} GROUP BY sp.ProductName ",productname);
                    sql5 = string.Format("SELECT sp.ProductName,COUNT(1),GROUP_CONCAT(tid) FROM StockProducts sp WHERE sp.ProductState='已下架'  and sp.ProductName=''{0} GROUP BY sp.ProductName ", productname);
                    sql6 = string.Format("SELECT sp.ProductName,COUNT(1),GROUP_CONCAT(tid) FROM StockProducts sp WHERE sp.ProductState='已出库'  and sp.ProductName=''{0} GROUP BY sp.ProductName ", productname);
                }
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("查询上架订单失败", ex);
                return null;
            }
            finally
            {
                myCon.Close();
            }
        }

    }
}
