/*******************************************************************
 * FileName: SqliteManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
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

            public static void CreateRole(string id, string name, string roleType) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Insert("role_list_table", new string[] { "'" + id + "'", "'" + name + "'", "'" + roleType + "'" });
                sqliteDB.CreateTable("equipment_list_table_" + id, new string[] { "tid", "id", "grade" }, new string[] { "int", "text", "text" });
                sqliteDB.CreateTable("consumable_list_table_" + id, new string[] { "tid", "id", "grade", "count" }, new string[] { "int", "text", "text", "text" });
                sqliteDB.CreateTable("stuff_list_table_" + id, new string[] { "tid", "id", "grade", "count" }, new string[] { "int", "text", "text", "text" });
                sqliteDB.Disconnect();
            } // end CreateRole

            public static void DeleteRole(string id) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Delete("role_list_table", new string[] { "id" }, new string[] { "'" + id + "'" });
                sqliteDB.DeleteTable("equipment_list_table_" + id);
                sqliteDB.DeleteTable("consumable_list_table_" + id);
                sqliteDB.DeleteTable("stuff_list_table_" + id);
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

            public static void GetPackInfoWithID(string id, string packName, ref Dictionary<int, string> infoDict) {
                string tableName = packName + "_list_table_" + id;
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                SqliteDataReader reader = sqliteDB.SelectWhere(tableName, new string[] { "id" }, new string[] { "tid" }, new string[] { "<" }, new string[] { "25" });

                if (null == reader) {
                    sqliteDB.Disconnect();
                    infoDict = new Dictionary<int, string>();
                } // end if

                try {
                    for (int i = 0; i < 25; i++) {
                        reader.Read();
                        string result = reader.GetString(reader.GetOrdinal("id"));

                        if (infoDict.ContainsKey(i)) {
                            infoDict[i] = result;
                        } else {
                            infoDict.Add(i, result);
                        } // end if
                    } // end for
                } catch (Exception ex) {
                    sqliteDB.Disconnect();
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
            } // end GetEquipmentPackInfoWithID
        } // end class SqliteManager
    } // end namespace Manager
} // end namespace Custom 
