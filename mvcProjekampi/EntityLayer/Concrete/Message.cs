using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReciverMail { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        
        public string MessageContent { get; set; }
        public string MessageDate { get; set; }

        [AllowHtml]

        public bool Draft { get; set; }
        public bool Trash { get; set; }
        public bool Read { get; set; }
        public bool Spam { get; set; }





    }
}
