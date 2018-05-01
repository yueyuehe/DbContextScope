using System;
using System.Collections.Generic;

namespace Authority.Entity
{
    public partial class Menu : BaseEntity
    {
        public Menu()
        {
            this.Childs = new HashSet<Menu>();
        }
        /// <summary>
        /// �˵�����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �˵�URL
        /// </summary>
        public string Url { get; set; }
       
        /// <summary>
        /// �Ӳ˵�
        /// </summary>
        public virtual ICollection<Menu> Childs { get; set; }

        /// <summary>
        /// ���˵�
        /// </summary>
        public virtual Menu Parent { get; set; }

    }
}
