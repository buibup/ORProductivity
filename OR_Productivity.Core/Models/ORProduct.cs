using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OR_Productivity.Core.Models
{
    public class ORProduct
    {
        public int RowID { get; set; }
        public DateTime? Date_Add { get; set; }
        public double? SumADC { get; set; }
        public double? Patient_Class1 { get; set; }
        public double? Patient_ClassHour1 { get; set; }
        public double? Patient_Class2 { get; set; }
        public double? Patient_ClassHour2 { get; set; }
        public double? Patient_Class3 { get; set; }
        public double? Patient_ClassHour3 { get; set; }
        public double? Patient_Class4 { get; set; }
        public double? Patient_ClassHour4 { get; set; }
        public double? Patient_Class5 { get; set; }
        public double? Patient_ClassHour5 { get; set; }
        public double? Patient_Class6 { get; set; }
        public double? Patient_ClassHour6 { get; set; }
        public double? Sum_Hour { get; set; }
        public double? Staff_Need_Mix { get; set; }
        public double? Staff_Need_RN { get; set; }
        public double? Staff_Need_NA { get; set; }
        public double? Staff_Actual_Mix { get; set; }
        public double? Staff_Actual_RN { get; set; }
        public double? Staff_Actual_NA { get; set; }
        public double? Productivity { get; set; }
        public double? Non_RN { get; set; }
        public double? RN_Non { get; set; }
        public double? Hour_User { get; set; }
    }
}
