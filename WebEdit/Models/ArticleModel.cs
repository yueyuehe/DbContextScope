using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEdit.Models
{
    public class ArticleModel
    {
        public Int32 Id { get; set; }
        public string HeadContent { get; set; }
        
             public string Title { get; set; }
        public ArticleModel GetbyId(Int32 id)
        {
            var poco = new PetaPoco.Database("sitecontent");
            string sql = @"SELECT id,[内容] AS HeadContent,[标题] as Title FROM dbo.Content WHERE ID =@0";
            return poco.Query<ArticleModel>(sql, id).First();
        }

        public void Update(ArticleModel model)
        {
            var sql = "update dbo.Content set 内容=@0 where id=@1 ";
            var poco = new PetaPoco.Database("sitecontent");
            poco.Execute(sql, model.HeadContent, model.Id);
        }
    }
}