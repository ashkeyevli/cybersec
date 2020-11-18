using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Botnet
{
    class cmd
    {
        public string ComType { get; private set; }
        public string ComContent { get; private set; }

        public cmd(string input_content)
        {
            string[] cmd_cnt = Regex.Split(input_content, configs.spliter);

            ComType = cmd_cnt[0];
            if (ComType != "exit")
            {
                ComContent = cmd_cnt[1];
            }
        }
    }
}
