




















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `qqliwuwang`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=.;Initial Catalog=qqliwuwang;User ID=sa;Password=sa123456`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace qqliwuwang
{

	public partial class GiftDB : Database
	{
		public GiftDB() 
			: base("qqliwuwang")
		{
			CommonConstruct();
		}

		public GiftDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			GiftDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static GiftDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new GiftDB();
        }

		[ThreadStatic] static GiftDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static GiftDB repo { get { return GiftDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    

	[TableName("dbo.t_gift_article")]



	[PrimaryKey("Id")]




	[ExplicitColumns]

    public partial class Article : GiftDB.Record<Article>  
    {



		[Column] public long Id { get; set; }





		[Column] public string ContentHtml { get; set; }



	}

    

	[TableName("dbo.t_gift_ArticleDetails")]



	[PrimaryKey("id")]




	[ExplicitColumns]

    public partial class ArticleDetail : GiftDB.Record<ArticleDetail>  
    {



		[Column] public int id { get; set; }





		[Column] public string ad_monitors { get; set; }





		[Column] public string approved_at { get; set; }





		[Column] public string comments_count { get; set; }





		[Column] public string content_type { get; set; }





		[Column] public string content_url { get; set; }





		[Column] public string cover_image_url { get; set; }





		[Column] public string created_at { get; set; }





		[Column] public string editor_id { get; set; }





		[Column] public string introduction { get; set; }





		[Column] public string liked { get; set; }





		[Column] public string likes_count { get; set; }





		[Column] public string limit_end_at { get; set; }





		[Column] public string media_type { get; set; }





		[Column] public string published_at { get; set; }





		[Column] public string share_msg { get; set; }





		[Column] public string shares_count { get; set; }





		[Column] public string short_title { get; set; }





		[Column] public string status { get; set; }





		[Column] public string template { get; set; }





		[Column] public string title { get; set; }





		[Column] public string type { get; set; }





		[Column] public string updated_at { get; set; }





		[Column] public string url { get; set; }





		[Column] public string PID { get; set; }



	}


}
