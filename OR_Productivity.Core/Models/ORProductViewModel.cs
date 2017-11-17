using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace OR_Productivity.Core.Models
{
    public class ORProductViewModel
    {
        [Column(Name = "Date_Add")]
        public DateTime DateAdd { get; set; }
        [Column(Name = "SumADC")]
        public int NumOfPatientAll { get; set; }
        [Column(Name = "Patient_Class1")]
        public int PatientClass1 { get; set; }
        [Column(Name = "Patient_ClassHour1")]
        public double HourPatientClass1 { get; set; }
        [Column(Name = "Patient_Class2")]
        public int PatientClass2 { get; set; }
        [Column(Name = "Patient_ClassHour2")]
        public double HourPatientClass2 { get; set; }
        [Column(Name = "Patient_Class3")]
        public int PatientClass3 { get; set; }
        [Column(Name = "Patient_ClassHour3")]
        public double HourPatientClass3 { get; set; }
        [Column(Name = "Patient_Class4")]
        public int PatientClass4 { get; set; }
        [Column(Name = "Patient_ClassHour4")]
        public double HourPatientClass4 { get; set; }
        [Column(Name = "Patient_Class5")]
        public int PatientClass5 { get; set; }
        [Column(Name = "Patient_ClassHour5")]
        public double HourPatientClass5 { get; set; }
        [Column(Name = "Patient_Class6")]
        public int PatientClass6 { get; set; }
        [Column(Name = "Patient_ClassHour6")]
        public double HourPatientClass6 { get; set; }
        [Column(Name = "Sum_Hour")]
        public double SumHourPatientAll { get; set; }
        [Column(Name = "Staff_Need_Mix")]
        public double NeddStaffAll { get; set; }
        [Column(Name = "Staff_Need_RN")]
        public double NeedStaffRn { get; set; }
        [Column(Name = "Staff_Need_NA")]
        public double NeedStaffNa { get; set; }
        [Column(Name = "Staff_Actual_Mix")]
        public double RealStaffAll { get; set; }
        [Column(Name = "Staff_Actual_RN")]
        public double RealStaffRn { get; set; }
        [Column(Name = "Staff_Actual_NA")]
        public double RealStaffNa { get; set; }
        [Column(Name = "Productivity")]
        public double Productivity { get; set; }
        [Column(Name = "RN_Non")]
        public double RnPerNa { get; set; }
    }
}
