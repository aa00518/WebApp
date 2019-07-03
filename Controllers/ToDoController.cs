using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Insight.Database;
using Microsoft.Data.Sqlite;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        [HttpGet]
        public IList<ToDo> Get()
        {
			SqliteConnection cn = new SqliteConnection(ConnectionStrings.sqliteDB.ConnectionString);
            List<ToDo> toDos = cn.QuerySql<ToDo>("select * from ToDos order by DateAdded desc").ToList();

            // var userList = cn.QuerySql<AppUser>("SELECT * FROM Beer WHERE Name LIKE @Name", new { Name = "%ipa%" });
            // cn.ExecuteSql("INSERT INTO Beer VALUES (ID, Name)", someAppUser);
			// User getUser = cn.QuerySql<User>("SELECT * FROM Users WHERE userID = @userID", new { userID = 1 }).FirstOrDefault();
            // int count2 = database.Connection().ExecuteScalarSql<int>("SELECT COUNT(*) FROM Beer WHERE Name LIKE @Name", new { Name = "IPA" });

            return toDos;
        }

        [HttpGet]
        [Route("GetToDoByID")]
        public ToDo GetToDoByID(long ID)
        {
            SqliteConnection cn = new SqliteConnection(ConnectionStrings.sqliteDB.ConnectionString);
            return cn.QuerySql<ToDo>("select * from ToDos where ID = @ID", new { ID = ID }).FirstOrDefault();
        }

        [HttpPost]
        [Route("InsertToDo")]
        public int InsertToDo([FromBody]ToDo toDo)
        {
            SqliteConnection cn = new SqliteConnection(ConnectionStrings.sqliteDB.ConnectionString);
            return cn.ExecuteSql("insert into ToDos (ToDoItem, DateAdded) values (@ToDoItem, @DateAdded)", new { ToDoItem = toDo.ToDoItem, DateAdded = toDo.DateAdded });
        }

        [HttpPost]
        [Route("DeleteToDo")]
        public int DeleteToDo([FromBody]ToDo toDo)
        {
            SqliteConnection cn = new SqliteConnection(ConnectionStrings.sqliteDB.ConnectionString);
            return cn.ExecuteSql("delete from ToDos where ID = @ID", new { ID = toDo.ID });
        }

        public class ToDo
        {
            public long ID { get; set; }
            public string ToDoItem { get; set; }
            public string DateAdded { get; set; }
        }
    }
}
