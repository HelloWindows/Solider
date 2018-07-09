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
                sqliteDB.Disconnect();
            } // end CreateRole

            public static void DeleteRole(string id) {
                SqliteDatabase sqliteDB = new SqliteDatabase("slidergame.db");
                sqliteDB.Delete("role_list_table", new string[] { "id" }, new string[] { "'" + id + "'" });
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
                } catch(Exception ex) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(ex.ToString());
#endif
                } // end try
                return null;
            } // end GetRoleWithID
        } // end class SqliteManager
    } // end namespace Manager
} // end namespace Custom 
