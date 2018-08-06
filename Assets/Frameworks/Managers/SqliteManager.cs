/*******************************************************************
 * FileName: SqliteManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.Middleware;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Manager {
        public static class SqliteManager {

            public static void Init() {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.CreateTable("player_table", new string[] { "username", "passwords"}, new[] { "text", "text" });
                sqliteDB.Disconnect();
            } // end SqliteManager

            private static string ToValue(int value) { return "'" + value + "'"; } // end ToValue
            private static string ToValue(float value) { return "'" + value + "'"; } // end ToValue
            private static string ToValue(string value) { return "'" + value + "'"; } // end ToValue

            /// <summary>
            /// 检测用户名是否存在, 存在返回true, 不存在返回 false
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <returns> 用户名是否存在 </returns>
            public static bool CheckUserName(string username) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere("player_table", new string[] { "username" },
                    new string[] { "username" }, new string[] { "=" }, new string[] { ToValue(username) });
                if (null == reader) {
                    sqliteDB.Disconnect();
                    return false;
                } // end if
                try{
                    if (reader.Read()) {
                        sqliteDB.Disconnect();
                        return true;
                    } // end if
                } catch (Exception ex) {
                    sqliteDB.Disconnect();
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try
                return false;
            } // end CheckUserName
            /// <summary>
            /// 检测登录，登录成功返回 true, 否则返回 false
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="passwords"> 密码 </param>
            /// <param name="msg"> 信息 </param>
            /// <returns> 是否登录成功 </returns>
            public static bool CheckLogin(string username, string passwords, out string msg) {
                if (false == CheckUserName(username)) {
                    msg = "用户名不存在!";
                    return false;
                } // end if
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere("player_table", new string[] { "username" },
                    new string[] { "username", "passwords" }, new string[] { "=", "=" }, new string[] { ToValue(username), ToValue(passwords) });
                if (null == reader) {
                    sqliteDB.Disconnect();
                    msg = "密码错误!";
                    return false;
                } // end if
                try {
                    if (reader.Read()) {
                        msg = "登录成功!";
                        sqliteDB.Disconnect();
                        return true;
                    } // end if
                } catch (Exception ex) {
                    sqliteDB.Disconnect();
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try
                sqliteDB.Disconnect();
                msg = "密码错误!";
                return false;
            } // end CheckLogin
            /// <summary>
            /// 注册用户
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="passwords"> 密码 </param>
            /// <returns> 是否注册成功 </returns>
            public static bool RegisterPlayer(string username, string passwords) {
                if (true == CheckUserName(username)) return false;
                // end if
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Insert("player_table", new string[] { ToValue(username), ToValue(passwords) });
                sqliteDB.CreateTable("role_list_table_" + username, new string[] { "roleindex", "name", "roletype" },
                    new string[] { "int", "text", "text" });
                sqliteDB.CreateTable("role_equip_table_" + username, new string[] { "roleindex", ConstConfig.WEAPON, ConstConfig.ARMOE, ConstConfig.SHOES }, 
                    new string[] { "int", "text", "text", "text" });
                sqliteDB.CreateTable("pack_list_table_" + username, new string[] { "roleindex", "gid", "id", "type", "grade", "count" },
                    new string[] { "int", "int", "text", "text", "text", "int" });
                sqliteDB.Disconnect();
                return true;
            } // end RegisterPanel
            /// <summary>
            /// 添加新角色数据
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="roleindex"> 角色索引 </param>
            /// <param name="name"> 角色姓名 </param>
            /// <param name="roleType"> 角色类型 </param>
            public static void CreateRole(string username, int roleindex, string name, string roleType) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Insert("role_list_table_" + username, new string[] { ToValue(roleindex), ToValue(name), ToValue(roleType) });
                sqliteDB.Insert("role_equip_table_" + username , new string[] { ToValue(roleindex), ToValue("0"), ToValue("0"), ToValue("0") });                          
                string[] packTypeList = { ConstConfig.EQUIP, ConstConfig.CONSUME, ConstConfig.STUFF };
                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    for (int j = 0; j < packTypeList.Length; j++) {
                        sqliteDB.Insert("pack_list_table_" + username, new string[] { "roleindex", "gid", "id", "type", "grade", "count" },
                            new string[] { ToValue(roleindex), ToValue(i), ToValue("0"), ToValue(packTypeList[j]), ToValue("Z"), ToValue(0) });
                    } // end for
                } // end for
                sqliteDB.Disconnect();

                int index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(username, roleindex, ConstConfig.EQUIP, index++, "10000" + i, "D", 0);
                    SetPackInfoWithID(username, roleindex, ConstConfig.EQUIP, index++, "10000" + (i + 4), "D", 0);
                    SetPackInfoWithID(username, roleindex, ConstConfig.EQUIP, index++, "10010" + i, "D", 0);
                    SetPackInfoWithID(username, roleindex, ConstConfig.EQUIP, index++, "10020" + i, "D", 0);
                } // end for
                index = 0;
                for (int i = 1; i < 5; i++)
                {
                    SetPackInfoWithID(username, roleindex, ConstConfig.CONSUME, index++, "20000" + i, "D", 66);
                } // end for
                index = 0;
                for (int i = 1; i < 5; i++)
                {
                    SetPackInfoWithID(username, roleindex, ConstConfig.STUFF, index++, "30000" + i, "D", 99);
                } // end for
            } // end CreateRole
            /// <summary>
            /// 删除角色数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            public static void DeleteRoleWithID(string username, int roleindex) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Delete("role_list_table_" + username, new string[] { "roleindex" }, new string[] { ToValue(roleindex) });
                sqliteDB.Delete("role_equip_table_" + username, new string[] { "roleindex" }, new string[] { ToValue(roleindex) });
                sqliteDB.Delete("pack_list_table_" + username, new string[] { "roleindex" }, new string[] { ToValue(roleindex) });
                sqliteDB.Disconnect();
            } // end DeleteRole
            /// <summary>
            /// 获取角色基本信息
            /// </summary>
            /// <param name="roleindex"> 用户名 </param>
            /// <param name="roleindex"> 角色索引 </param>
            /// <returns> 角色基本信息 [0] 为姓名,[1] 角色类型。不存在返回null </returns>
            public static string[] GetRoleWithID(string username, int roleindex) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader =sqliteDB.SelectWhere("role_list_table_" + username, new string[] { "name", "roletype" }, 
                    new string[] { "roleindex" }, new string[] { "=" }, new string[] { ToValue(roleindex) });
                if (null == reader) {
                    sqliteDB.Disconnect();
                    return null;
                } // end if
                try {
                    while (reader.Read()) {
                        string[] result = new string[2];
                        result[0] = reader.GetString(reader.GetOrdinal("name"));
                        result[1] = reader.GetString(reader.GetOrdinal("roletype"));
                        sqliteDB.Disconnect();
                        return result;
                    } // end while
                } catch (Exception ex) {
                    sqliteDB.Disconnect();
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try
                return null;
            } // end GetRoleWithID
            /// <summary>
            /// 获取角色穿戴的装备数据
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="roleindex"> 角色索引 </param>
            /// <param name="dict"> 穿戴的装备数据 </param>
            public static void GetWearInfoWithID(string username, int roleindex, out Dictionary<string, string> dict) {
                dict = new Dictionary<string, string>();
                string tableName = "role_equip_table_" + username;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "weapon", "armor", "shoes" }, 
                    new string[] { "roleindex" }, new string[] { "=" }, new string[] { ToValue(roleindex) });
                if (null == reader) {
                    sqliteDB.Disconnect();
                    return;
                } // end if
                try {
                    while (reader.Read()) {
                        dict["weapon"] = reader.GetString(reader.GetOrdinal("weapon"));
                        dict["armor"] = reader.GetString(reader.GetOrdinal("armor"));
                        dict["shoes"] = reader.GetString(reader.GetOrdinal("shoes"));
                    } // end while
                } catch (Exception ex) {
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try
                sqliteDB.Disconnect();
            } // end GetWearInfoWithID
            /// <summary>
            /// 修改角色穿戴的装备数据
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="roleindex"> 角色索引 </param>
            /// <param name="type"> 装备类型 </param>
            /// <param name="id"> 装备id </param>
            public static void SetWearInfoWithID(string username, int roleindex, string type, string id) {
                string tableName = "role_equip_table_" + username;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                try {
                    sqliteDB.Update(tableName, new string[] { type }, new string[] { id }, 
                        new string[] { "roleindex" }, new string[] { "=" }, new string[] { ToValue(roleindex) });
                } catch (Exception ex) {
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try              
                sqliteDB.Disconnect();
            } // end SetWearInfoWithID
            /// <summary>
            /// 获取对应背包的数据
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="roleindex"> 角色索引 </param>
            /// <param name="packType"> 背包类型 </param>
            /// <param name="dict"> 背包数据 </param>
            public static void GetPackInfoWithID(string username, int roleindex, string packType, out Dictionary<int, string[]> dict) {
                dict = new Dictionary<int, string[]>();
                string tableName = "pack_list_table_" + username;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "gid", "id", "count" },
                    new string[] { "roleindex", "gid", "type" }, new string[] { "=", "<", "=" }, new string[] { ToValue(roleindex), ToValue("25"), ToValue(packType) });
                if (null == reader) {
                    sqliteDB.Disconnect();
                    return;
                } // end if
                try {
                    while (reader.Read()) {
                        int gid = reader.GetInt32(reader.GetOrdinal("gid"));
                        dict[gid] = new string[2];
                        dict[gid][0] = reader.GetString(reader.GetOrdinal("id"));
                        dict[gid][1] = reader.GetInt32(reader.GetOrdinal("count")).ToString();
                    } // end while
                } catch (Exception ex) {
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try
                sqliteDB.Disconnect();
            } // end GetEquipmentPackInfoWithID
            /// <summary>
            /// 获取对应背包根据物品等级排序后的数据
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="roleindex"> 角色索引 </param>
            /// <param name="type"> 背包类型 </param>
            /// <param name="dict"> 排序后的背包数据 </param>
            public static void GetArrangePackInfo(string username, int roleindex, string type, ref Dictionary<int, string[]> dict) {
                string tableName = "pack_list_table_" + roleindex;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectOrder(tableName, new string[] { "id", "count" }, 
                    new string[] { "gid", "type" }, new string[] { "<", "=" }, new string[] { ToValue("25"), ToValue(type) }, new string[] { "grade" }, "ASC");
                if (null == reader) {
                    sqliteDB.Disconnect();
                    dict = new Dictionary<int, string[]>();
                    return;
                } // end if
                try {
                    int gid = 0;
                    while (reader.Read()) {
                        dict[gid] = new string[2];
                        dict[gid][0] = reader.GetString(reader.GetOrdinal("id"));
                        dict[gid][1] = reader.GetInt32(reader.GetOrdinal("count")).ToString();
                        gid++;
                    } // end while
                } catch (Exception ex) {
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try
                sqliteDB.Disconnect();
            } // end GetArrangePackInfoWithID
            /// <summary>
            /// 修改对应背包和对应格子的数据
            /// </summary>
            /// <param name="username"> 用户名 </param>
            /// <param name="roleindex"> 角色索引 </param>
            /// <param name="type"> 背包类型 </param>
            /// <param name="gid"> 格子id </param>
            /// <param name="id"> 物品id </param>
            /// <param name="grade"> 物品品级 </param>
            /// <param name="count"> 物品数量 </param>
            public static void SetPackInfoWithID(string username, int roleindex, string type, int gid, string id, string grade, int count) {
                string tableName = "pack_list_table_" + username;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                try {
                    sqliteDB.Update(tableName, new string[] { "id", "grade", "count" }, new string[] { ToValue(id), ToValue(grade), ToValue(count) }, 
                        new string[] { "roleindex", "gid", "type" }, new string[] { "=", "=", "=" }, new string[] { ToValue(roleindex), ToValue(gid), ToValue(type) });
                } catch (Exception ex) {
                    ConsoleTool.SetConsole(ex.ToString());
                } // end try              
                sqliteDB.Disconnect();
            } // end SetPackInfoWithID
        } // end class SqliteManager
    } // end namespace Manager
} // end namespace Custom 
