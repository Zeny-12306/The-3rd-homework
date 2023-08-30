using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools_For_Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools_For_Translation.Tests
{
    [TestClass()]
    public class ToolTests
    {
        [TestMethod()]
        public void check_inputTest()
        {
            //检测check_input函数能否正确判断输入数据
            var testdata = new string[] { "10", "1.0","1,000.0","wrong_input","1a23","1.1.1"};
            var res = new bool[] { true, true, true, false, false, false  };
            for(int i = 0; i < testdata.Length; i++)
            {
                Assert.AreEqual( Tool.check_input(testdata[i]), res[i] );
            }
            
        }
    }
}