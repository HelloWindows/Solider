/*******************************************************************
 * FileName: SqliteManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Middleware;
using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Manager {
        public static class SqliteManager {

            public static void Init() {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.CreateTable("role_list_table", new string[] { "id", "name", "roletype" }, new string[] { "text", "text", "text" });
                sqliteDB.CreateTable("role_equip_table", new string[] { "id", "weapon", "armor", "shoes" }, new string[] { "text", "text", "text", "text" });
                sqliteDB.CreateTable("role_info_table", new string[] { "id", "hp", "mp", "xhp", "xmp", "natk", "xatk", "nmgk", "xmgk", "hot", "mot", "def", "rgs", "asp", "msp", "crt" },
                    new string[] { "text", "int", "int", "int", "int", "int", "int", "int", "int", "int", "int", "int", "int", "real", "real", "real" });
                sqliteDB.Disconnect();
            } // end SqliteManager

            private static string ToValue(int value) { return "'" + value + "'"; } // end ToValue
            private static string ToValue(float value) { return "'" + value + "'"; } // end ToValue
            private static string ToValue(string value) { return "'" + value + "'"; } // end ToValue
            /// <summary>
            /// 添加新角色数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <param name="name"> 角色姓名 </param>
            /// <param name="roleType"> 角色类型 </param>
            public static void CreateRole(string roleID, string name, string roleType) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Insert("role_list_table", new string[] { ToValue(roleID), ToValue(name), ToValue(roleType) });
                sqliteDB.Insert("role_equip_table", new string[] { ToValue(roleID), ToValue("0"), ToValue("0"), ToValue("0") });
                sqliteDB.Insert("role_info_table", new string[] { ToValue(roleID), ToValue(100), ToValue(100), ToValue(100), ToValue(100), ToValue(5), ToValue(10), ToValue(5), ToValue(10), ToValue(1), ToValue(0), ToValue(5), ToValue(5), ToValue(1f), ToValue(0.8f), ToValue(0) });
                sqliteDB.CreateTable("pack_list_table_" + roleID, new string[] { "tid", "id", "gid", "type", "grade", "count" }, new string[] { "int", "text", "int", "text", "text", "int" });
                string[] packTypeList = { ConstConfig.EQUIP, ConstConfig.CONSUME, ConstConfig.STUFF };
                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    for (int j = 0; j < packTypeList.Length; j++) {
                        sqliteDB.Insert("pack_list_table_" + roleID, new string[] { "tid", "id", "gid", "type", "grade", "count" },
                            new string[] { ToValue(i * 3 + j), ToValue("0"), ToValue(i), ToValue(packTypeList[j]), ToValue("Z"), ToValue(0) });
                    } // end for
                } // end for
                sqliteDB.Disconnect();

                int index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(roleID, "equip", index++, "10000" + i, "D", 0);
                    SetPackInfoWithID(roleID, "equip", index++, "10000" + (i + 4), "D", 0);
                    SetPackInfoWithID(roleID, "equip", index++, "10010" + i, "D", 0);
                    SetPackInfoWithID(roleID, "equip", index++, "10020" + i, "D", 0);
                } // end for
                index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(roleID, "consume", index++, "20000" + i, "D", 66);
                } // end for
                index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(roleID, "stuff", index++, "30000" + i, "D", 99);
                } // end for
            } // end CreateRole
            /// <summary>
            /// 删除角色数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            public static void DeleteRoleWithID(string roleID) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Delete("role_list_table", new string[] { "id" }, new string[] { roleID });
                sqliteDB.Delete("role_equip_table", new string[] { "id" }, new string[] { roleID });
                sqliteDB.Delete("role_info_table", new string[] { "id" }, new string[] { roleID });
                sqliteDB.DeleteTable("pack_list_table_" + roleID);
                sqliteDB.Disconnect();
            } // end DeleteRole
            /// <summary>
            /// 获取角色基本信息
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <returns> 角色基本信息 [0] 为姓名,[1] 角色类型。不存在返回null </returns>
            public static string[] GetRoleWithID(string roleID) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader =sqliteDB.SelectWhere("role_list_table", new string[] { "name", "roletype" }, new string[] { "id" }, new string[] { "=" }, new string[] { roleID });

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
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                return null;
            } // end GetRoleWithID
            /// <summary>
            /// 获取角色初始化状态的信息数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <param name="dict"> 角色初始化状态的信息数据 </param>
            public static void GetRoleInfoWithID(string roleID, ref Dictionary<string, float> dict) {
                string tableName = "role_info_table";
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "hp", "mp", "xhp", "xmp", "natk", "xatk", "nmgk", "xmgk", "hot", "mot", "def", "rgs", "asp", "msp", "crt" }, 
                    new string[] { "id"}, new string[] { "=" }, new string[] { roleID });

                if (null == reader) {
                    sqliteDB.Disconnect();
                    dict = new Dictionary<string, float>();
                    return;
                } // end if

                try {
                    while (reader.Read()) {
                        dict["hp"] = reader.GetInt32(reader.GetOrdinal("hp"));
                        dict["mp"] = reader.GetInt32(reader.GetOrdinal("mp"));
                        dict["xhp"] = reader.GetInt32(reader.GetOrdinal("xhp"));
                        dict["xmp"] = reader.GetInt32(reader.GetOrdinal("xmp"));
                        dict["natk"] = reader.GetInt32(reader.GetOrdinal("natk"));
                        dict["xatk"] = reader.GetInt32(reader.GetOrdinal("xatk"));
                        dict["nmgk"] = reader.GetInt32(reader.GetOrdinal("nmgk"));
                        dict["xmgk"] = reader.GetInt32(reader.GetOrdinal("xmgk"));
                        dict["hot"] = reader.GetInt32(reader.GetOrdinal("hot"));
                        dict["mot"] = reader.GetInt32(reader.GetOrdinal("mot"));
                        dict["def"] = reader.GetInt32(reader.GetOrdinal("def"));
                        dict["rgs"] = reader.GetInt32(reader.GetOrdinal("rgs"));
                        dict["asp"] = reader.GetFloat(reader.GetOrdinal("asp"));
                        dict["msp"] = reader.GetFloat(reader.GetOrdinal("msp"));
                        dict["crt"] = reader.GetFloat(reader.GetOrdinal("crt"));
                    } // end while
                } catch (Exception ex) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                sqliteDB.Disconnect();
            } // end GetRoleInfoWithID
            /// <summary>
            /// 获取角色穿戴的装备数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <param name="dict"> 穿戴的装备数据 </param>
            public static void GetWearInfoWithID(string roleID, out Dictionary<string, string> dict) {
                dict = new Dictionary<string, string>();
                string tableName = "role_equip_table";
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "weapon", "armor", "shoes" }, new string[] { "id" }, new string[] { "=" }, new string[] { roleID });
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
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                sqliteDB.Disconnect();
            } // end GetWearInfoWithID
            /// <summary>
            /// 修改角色穿戴的装备数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <param name="type"> 装备类型 </param>
            /// <param name="id"> 装备id </param>
            public static void SetWearInfoWithID(string roleID, string type, string id) {
                string tableName = "role_equip_table";
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                try {
                    sqliteDB.Update(tableName, new string[] { type }, new string[] { id }, 
                        new string[] { "id" }, new string[] { "=" }, new string[] { roleID });
                } catch (Exception ex) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try              
                sqliteDB.Disconnect();
            } // end SetWearInfoWithID
            /// <summary>
            /// 获取对应背包的数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <param name="packType"> 背包类型 </param>
            /// <param name="dict"> 背包数据 </param>
            public static void GetPackInfoWithID(string roleID, string packType, out Dictionary<int, string[]> dict) {
                dict = new Dictionary<int, string[]>();
                string tableName = "pack_list_table_" + roleID;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "gid", "id", "count" }, new string[] { "gid", "type" }, new string[] { "<", "=" }, new string[] { "25", packType });

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
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                sqliteDB.Disconnect();
            } // end GetEquipmentPackInfoWithID
            /// <summary>
            /// 获取对应背包根据物品等级排序后的数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <param name="type"> 背包类型 </param>
            /// <param name="dict"> 排序后的背包数据 </param>
            public static void GetArrangePackInfo(string roleID, string type, ref Dictionary<int, string[]> dict) {
                string tableName = "pack_list_table_" + roleID;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectOrder(tableName, new string[] { "id", "count" }, new string[] { "gid", "type" }, new string[] { "<", "=" }, new string[] { "25", type }, new string[] { "grade" }, "ASC");

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
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                sqliteDB.Disconnect();
            } // end GetArrangePackInfoWithID

            /// <summary>
            /// 修改对应背包和对应格子的数据
            /// </summary>
            /// <param name="roleID"> 角色id </param>
            /// <param name="type"> 背包类型 </param>
            /// <param name="gid"> 格子id </param>
            /// <param name="id"> 物品id </param>
            /// <param name="grade"> 物品品级 </param>
            /// <param name="count"> 物品数量 </param>
            public static void SetPackInfoWithID(string roleID, string type, int gid, string id, string grade, int count) {
                string tableName = "pack_list_table_" + roleID;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                try {
                    sqliteDB.Update(tableName, new string[] { "id", "grade", "count" }, new string[] { id, grade, count.ToString() }, 
                        new string[] { "gid", "type" }, new string[] { "=", "=" }, new string[] { gid.ToString(), type });
                } catch (Exception ex) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try              
                sqliteDB.Disconnect();
            } // end SetPackInfoWithID
        } // end class SqliteManager
    } // end namespace Manager
} // end namespace Custom 
