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
                sqliteDB.Disconnect();
            } // end SqliteManager

            private static string ToValue(string value) { return "'" + value + "'"; } // end ToValue
            private static string ToValue(int value) { return "'" + value + "'"; } // end ToValue

            public static void CreateRole(string id, string name, string roleType) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Insert("role_list_table", new string[] { ToValue(id), ToValue(name), ToValue(roleType) });
                sqliteDB.CreateTable("pack_list_table_" + id, new string[] { "tid", "id", "gid", "type", "grade", "count" }, new string[] { "int", "text", "int", "text", "text", "int" });
                string[] types = { "equit", "consume", "stuff" };

                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    for (int j = 0; j < types.Length; j++) {
                        sqliteDB.Insert("pack_list_table_" + id, new string[] { "tid", "id", "gid", "type", "grade", "count" },
                            new string[] { ToValue(i * 3 + j), ToValue("0"), ToValue(i), ToValue(types[j]), ToValue("Z"), ToValue(0) });
                    } // end for
                } // end for
                int index = 0;
                for (int i = 1; i < 5; i++) {
                    SetPackInfoWithID(id, "equit", index++, "10000" + i, "D", 1);
                    SetPackInfoWithID(id, "equit", index++, "10000" + (i + 4), "D", 1);
                    SetPackInfoWithID(id, "equit", index++, "10010" + i, "D", 1);
                    SetPackInfoWithID(id, "equit", index++, "10020" + i, "D", 1);
                } // end for
                sqliteDB.Disconnect();
            } // end CreateRole

            public static void DeleteRole(string id) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Delete("role_list_table", new string[] { "id" }, new string[] { "'" + id + "'" });
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
                string[] result = new string[2];

                try {
                    while (reader.Read()) {
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

            public static void GetPackInfoWithID(string id, string type, ref Dictionary<int, string[]> idDict) {
                string tableName = "pack_list_table_" + id;
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
