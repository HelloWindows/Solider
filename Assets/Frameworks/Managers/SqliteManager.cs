﻿/*******************************************************************
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
                sqliteDB.CreateTable("role_info_table", new string[] { "id", "hp", "mp", "xhp", "xmp", "natk", "xatk", "nmgk", "xmgk", "hot", "mot", "def", "rgs", "asp", "msp", "crt" },
                    new string[] { "text", "int", "int", "int", "int", "int", "int", "int", "int", "int", "int", "int", "int", "real", "real", "real" });
                sqliteDB.Disconnect();
            } // end SqliteManager

            private static string ToValue(int value) { return "'" + value + "'"; } // end ToValue
            private static string ToValue(float value) { return "'" + value + "'"; } // end ToValue
            private static string ToValue(string value) { return "'" + value + "'"; } // end ToValue
 
            public static void CreateRole(string id, string name, string roleType) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Insert("role_list_table", new string[] { ToValue(id), ToValue(name), ToValue(roleType) });
                sqliteDB.Insert("role_info_table", new string[] { ToValue(id), ToValue(100), ToValue(100), ToValue(100), ToValue(100), ToValue(5), ToValue(10), ToValue(5), ToValue(10), ToValue(1), ToValue(0), ToValue(5), ToValue(5), ToValue(1f), ToValue(0.8f), ToValue(0) });
                sqliteDB.CreateTable("pack_list_table_" + id, new string[] { "tid", "id", "gid", "type", "grade", "count" }, new string[] { "int", "text", "int", "text", "text", "int" });
                string[] types = { "equip", "consume", "stuff" };
                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    for (int j = 0; j < types.Length; j++) {
                        sqliteDB.Insert("pack_list_table_" + id, new string[] { "tid", "id", "gid", "type", "grade", "count" },
                            new string[] { ToValue(i * 3 + j), ToValue("0"), ToValue(i), ToValue(types[j]), ToValue("Z"), ToValue(0) });
                    } // end for
                } // end for

                int index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(id, "equip", index++, "10000" + i, "D", 0);
                    SetPackInfoWithID(id, "equip", index++, "10000" + (i + 4), "D", 0);
                    SetPackInfoWithID(id, "equip", index++, "10010" + i, "D", 0);
                    SetPackInfoWithID(id, "equip", index++, "10020" + i, "D", 0);
                } // end for
                index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(id, "consume", index++, "20000" + i, "D", 66);
                } // end for
                index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(id, "stuff", index++, "30000" + i, "D", 99);
                } // end for
                sqliteDB.Disconnect();
            } // end CreateRole

            public static void DeleteRole(string id) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Delete("role_list_table", new string[] { "id" }, new string[] { "'" + id + "'" });
                sqliteDB.Delete("role_info_table", new string[] { "id" }, new string[] { "'" + id + "'" });
                sqliteDB.DeleteTable("pack_list_table_" + id);
                sqliteDB.Disconnect();
            } // end DeleteRole

            public static string[] GetRoleWithID(string id) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader =sqliteDB.SelectWhere("role_list_table", new string[] { "name", "roletype" }, new string[] { "id" }, new string[] { "=" }, new string[] { id });

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

            public static void GetRoleInfoWithID(string playerId, ref Dictionary<string, float> dict) {
                string tableName = "role_info_table";
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "hp", "mp", "xhp", "xmp", "natk", "xatk", "nmgk", "xmgk", "hot", "mot", "def", "rgs", "asp", "msp", "crt" }, 
                    new string[] { "id"}, new string[] { "=" }, new string[] { playerId });

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

            public static void GetPackInfoWithID(string playerId, string type, ref Dictionary<int, string[]> idDict) {
                string tableName = "pack_list_table_" + playerId;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "gid", "id", "count" }, new string[] { "gid", "type" }, new string[] { "<", "=" }, new string[] { "25", type });

                if (null == reader) {
                    sqliteDB.Disconnect();
                    idDict = new Dictionary<int, string[]>();
                    return;
                } // end if

                try {
                    while (reader.Read()) {
                        int gid = reader.GetInt32(reader.GetOrdinal("gid"));
                        idDict[gid] = new string[2];
                        idDict[gid][0] = reader.GetString(reader.GetOrdinal("id"));
                        idDict[gid][1] = reader.GetInt32(reader.GetOrdinal("count")).ToString();
                    } // end while
                } catch (Exception ex) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                sqliteDB.Disconnect();
            } // end GetEquipmentPackInfoWithID

            public static void GetArrangePackInfo(string playerId, string type, ref Dictionary<int, string[]> idDict) {
                string tableName = "pack_list_table_" + playerId;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectOrder(tableName, new string[] { "id", "count" }, new string[] { "gid", "type" }, new string[] { "<", "=" }, new string[] { "25", type }, new string[] { "grade" }, "ASC");

                if (null == reader) {
                    sqliteDB.Disconnect();
                    idDict = new Dictionary<int, string[]>();
                    return;
                } // end if

                try {
                    int gid = 0;
                    while (reader.Read()) {
                        idDict[gid] = new string[2];
                        idDict[gid][0] = reader.GetString(reader.GetOrdinal("id"));
                        idDict[gid][1] = reader.GetInt32(reader.GetOrdinal("count")).ToString();
                        gid++;
                    } // end while
                } catch (Exception ex) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                sqliteDB.Disconnect();
            } // end GetArrangePackInfoWithID

            public static void SetPackInfoWithID(string playerId, string type, int gid, string id, string grade, int count) {
                string tableName = "pack_list_table_" + playerId;
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
