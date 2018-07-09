/*******************************************************************
 * FileName: SqliteDatabase.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

/* For Example:
 * 
 * #if UNITY_EDITOR
 *      SqliteDatabase db = new SqliteDatabase("data source=game.db"); 
 *      数据库将保存在项目的根目录
 *      
 * #elif UNITY_STANDALONE_WIN
 * 	    string appDBPath = Application.dataPath  + "/game.db"
 * 	    SqliteDatabase db = new SqliteDatabase(@"Data Source=" + appDBPath);
 * 	    数据库将保存在 app_Data 文件夹内
 * 	    
 * #elif UNITY_STANDALONE_OSX
 *      string appDBPath = Application.dataPath + "/game.db";
 *      SqliteDatabase db = new SqliteDatabase(@"Data Source=" + appDBPath);  
 *      
 * #elif UNITY_ANDROID
 *      string appDBPath = Application.persistentDataPath  + "/game.db";
 *      SqliteDatabase db = new SqliteDatabase("URI=file:" + appDBPath);
 *      
 * #elif UNITY_IPHONE
 *      string appDBPath = Application.persistentDataPath + "/game.db";
 *      SqliteDatabase db = new SqliteDatabase(@"Data Source=" + appDBPath);
 * #endif
 */
using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Middleware {
        public class SqliteDatabase {
            private SqliteDataReader reader;
            private SqliteCommand dbCommand;
            private SqliteConnection dbConnection;

            /// <summary>
            /// 构造函数
            /// </summary>
            public SqliteDatabase() {
            } // end SqliteDatabase
          
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="connectionString"> 数据库路径 </param>
            public SqliteDatabase(string connectionString) {
                Connect(connectionString);
            } // end SqliteDatabase

            /// <summary>
            /// 连接数据库
            /// </summary>
            /// <param name="connectionString"> 数据库名 </param>
            public void Connect(string connectionString) {
                string path = "";
#if UNITY_EDITOR
                path = "data source=" + connectionString;
#elif UNITY_STANDALONE_WIN
                path = @"Data Source=" + Application.dataPath + "/" + connectionString;	    
#elif UNITY_STANDALONE_OSX
                path = @"Data Source=" + Application.dataPath + "/" + connectionString;	     
#elif UNITY_ANDROID
                path = "URI=file:" + Application.persistentDataPath + "/" + connectionString;	    
#elif UNITY_IPHONE
                path = @"Data Source=" + Application.persistentDataPath + "/" + connectionString;	    
#endif
                try {
                    dbConnection = new SqliteConnection(path);
                    dbConnection.Open();
                } catch (Exception ex) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
            } // end Open

            /// <summary>
            /// 断开连接
            /// </summary>
            public void Disconnect() {
                if (dbCommand != null) dbCommand.Dispose();
                // end if
                dbCommand = null;
                if (reader != null) reader.Dispose();
                // end if
                reader = null;
                if (dbConnection != null) dbConnection.Close ();
                // end if
                dbConnection = null;
            } // end Disconnect

            /// <summary>
            /// 执行命令
            /// </summary>
            /// <param name="sqlQuery"> sql语句 </param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader ExecuteQuery(string sqlQuery) {
                try {
                    dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandText = sqlQuery;
                    reader = dbCommand.ExecuteReader();
                } catch (Exception ex) {
                    reader = null;
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                return reader;
            } // end SqliteDataReader

            /// <summary>
            /// 创建表
            /// </summary>
            /// <param name="name"> 表名 </param>
            /// <param name="cols"> 表头 </param>
            /// <param name="colsType"> 数据类型 </param>
            /// <returns></returns>
            public SqliteDataReader CreateTable(string tableName, string[] cols, string[] colsType) {
                if (cols.Length != colsType.Length) {
#if __MY_DEBUG__
                    reader = null;
                    ConsoleTool.SetConsole("CreateTable columns.Length != values.Length");
#endif
                    return reader;
                } // end if
                string query = "CREATE TABLE " + tableName + " (" + cols[0] + " " + colsType[0];
                for (int i = 1; i < cols.Length; ++i) {
                    query += ", " + cols[i] + " " + colsType[i];
                } // end for
                query += ")";
                return ExecuteQuery(query);
            } // end CreateTable

            /// <summary>
            /// 查询表
            /// </summary>
            /// <param name="tableName"> 表名 </param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader ReadTable(string tableName) {
                string query = "SELECT * FROM " + tableName;
                return ExecuteQuery(query);
            } // end ReadTable

            /// <summary>
            /// 查询数据
            /// </summary>
            /// <param name="tableName"> 表名 </param>
            /// <param name="items"> 查询项 </param>
            /// <param name="cols"> 条件列 </param>
            /// <param name="operation"> 条件 </param>
            /// <param name="values"> 条件值 </param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader SelectWhere(string tableName, string[] items, string[] cols, string[] operation, string[] values) {
                if (cols.Length != operation.Length || operation.Length != values.Length) {
#if __MY_DEBUG__
                    reader = null;
                    ConsoleTool.SetConsole("SelectWhere col.Length != operation.Length != values.Length");
#endif
                    return reader;
                } // end if
                string query = "SELECT " + items[0];
                for (int i = 1; i < items.Length; ++i) {
                    query += ", " + items[i];
                } // end for
                query += " FROM " + tableName + " WHERE " + cols[0] + operation[0] + "'" + values[0] + "' ";
                for (int i = 1; i < cols.Length; ++i) {
                    query += " AND " + cols[i] + operation[i] + "'" + values[0] + "' ";
                } // end for
                return ExecuteQuery(query);
            } // end SelectWhere

            /// <summary>
            /// 升序查询
            /// </summary>
            /// <param name="tableName"> 表名 </param>
            /// <param name="items"> 查询项 </param>
            /// <param name="cols"> 排序列 </param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader SelectOrderASC(string tableName, string[] items, string[] cols) {
                return SelectOrder(tableName, items, cols, "ASC");
            } // end SelectOrderASC

            /// <summary>
            /// 降序查询
            /// </summary>
            /// <param name="tableName"> 表名 </param>
            /// <param name="items"> 查询项 </param>
            /// <param name="cols"> 排序列 </param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader SelectOrderDESC(string tableName, string[] items, string[] cols) {
                return SelectOrder(tableName, items, cols, "DESC");
            } // end SelectOrderASC

            private SqliteDataReader SelectOrder(string tableName, string[] items, string[] cols, string order) {
                string query = "SELECT " + items[0];

                for (int i = 1; i < items.Length; ++i) {
                    query += ", " + items[i];
                } // end for
                query += " FROM " + tableName + " ORDER BY " + cols[0];
                for (int i = 1; i < cols.Length; ++i) {
                    query += ", " + cols[i];
                } // end for
                query += " " + order;
                return ExecuteQuery(query);
            } // end SelectOrderASC

            /// <summary>
            /// 插入一条数据
            /// </summary>
            /// <param name="tableName"> 表名 </param>
            /// <param name="values"> 插入的数据 </param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader Insert(string tableName, string[] values) {
                string query = "INSERT INTO " + tableName + " VALUES (" + values[0];
                for (int i = 1; i < values.Length; ++i) {
                    query += ", " + values[i];
                } // end for
                query += ")";
                return ExecuteQuery(query);
            } // end Insert

            /// <summary>
            /// 插入一条数据
            /// </summary>
            /// <param name="tableName"> 表名 </param>
            /// <param name="cols"></param>
            /// <param name="values"></param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader Insert(string tableName, string[] cols, string[] values) {
                if (cols.Length != values.Length) {
#if __MY_DEBUG__
                    reader = null;
                    ConsoleTool.SetConsole("Insert columns.Length != values.Length");
#endif
                    return reader;
                } // end if
                string query = "INSERT INTO " + tableName + "(" + cols[0];
                for (int i = 1; i < cols.Length; ++i) {
                    query += ", " + cols[i];
                } // end for
                query += ") VALUES (" + values[0];
                for (int i = 1; i < values.Length; ++i) {
                    query += ", " + values[i];
                } // end for
                query += ")";
                return ExecuteQuery(query);
            } // end Insert

            /// <summary>
            /// 更新一条数据
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="cols"></param>
            /// <param name="colsvalues"></param>
            /// <param name="selectkey"></param>
            /// <param name="selectvalue"></param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader Update(string tableName, string[] cols, string[] colsvalues, string selectkey, string selectvalue) {
                string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];
                for (int i = 1; i < colsvalues.Length; ++i) {
                    query += ", " + cols[i] + " =" + colsvalues[i];
                } // end for
                query += " WHERE " + selectkey + " = " + selectvalue + " ";
                return ExecuteQuery(query);
            } // end Update

            /// <summary>
            /// 删除一条数据
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="cols"></param>
            /// <param name="colsvalues"></param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader Delete(string tableName, string[] cols, string[] colsvalues) {
                string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];
                for (int i = 1; i < colsvalues.Length; ++i) {
                    query += " or " + cols[i] + " = " + colsvalues[i];
                } // end for
                return ExecuteQuery(query);
            } // end Delete

            /// <summary>
            /// 删除表
            /// </summary>
            /// <param name="tableName"> 表名 </param>
            /// <returns> 结果读取器 </returns>
            public SqliteDataReader DeleteTable(string tableName) {
                string query = "DROP TABLE " + tableName;
                return ExecuteQuery(query);
            } // end DeleteTable
        } // end class SqliteDatabase
    } // end namespace Middleware
} // end namespace Framework 
