using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrealIRCD.JPRC.Client
{
    public class JRPCClientOption
    {
        /// <summary>
        /// IP+端口
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// ApiUse用户名
        /// </summary>
        public string ApiUser { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
    }
}
