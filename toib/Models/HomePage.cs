using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToibSolovyov.Models
{
    public class HomePage
    {
        public Test Test1 { get; set; } = new Test() {ControllerName = "Test1" };

        public Test Test2 { get; set; } = new Test() { ControllerName = "Test2" };

        public Test Test3 { get; set; } = new Test() { ControllerName = "Test3" };

        public Test TestFixed1 { get; set; } = new Test() { ControllerName = "TestFixed1" };

        public Test TestFixed2 { get; set; } = new Test() { ControllerName = "TestFixed2" };

        public Test TestFixed3 { get; set; } = new Test() { ControllerName = "TestFixed3" };
    }
}