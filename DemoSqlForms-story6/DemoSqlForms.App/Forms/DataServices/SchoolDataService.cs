﻿
// *******************************************************************************************************
// This code is auto generated by Platz.ObjectBuilder template, any changes made to this code will be lost
// *******************************************************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Platz.SqlForms;
using DemoSqlForms.Database.Model;

namespace Default
{
    #region Interface 

    public partial interface IMyDataService
    {
        List<EnrollmentDetails> GetEnrollmentDetailsList(params object[] parameters);
    }

    #endregion

    #region Data Service 

    public partial class MyDataService : DataServiceBase<DemoSqlForms.Database.Model.SchoolContext>, IMyDataService
    {
        public List<EnrollmentDetails> GetEnrollmentDetailsList(params object[] parameters)
        {
            var p1 = (Int32)parameters[0];

            using (var db = GetDbContext())
            {
                var query =
                    from c in db.Course 
                    join e in db.Enrollment on c.CourseID equals e.CourseID
                    where e.StudentID == p1
                    select new EnrollmentDetails
                    {
                        EnrollmentID = e.EnrollmentID,
                        CourseID = e.CourseID,
                        Grade = e.Grade,
                        StudentID = e.StudentID,
                        Credits = c.Credits,
                        Title = c.Title,
                    };

                var result = query.ToList();
                return result;
            }
        }

    }

    #endregion

    #region Entities

    public partial class EnrollmentDetails
    {
        public Int32 EnrollmentID { get; set; }
        public Int32 CourseID { get; set; }
        public Grade? Grade { get; set; }
        public Int32 StudentID { get; set; }
        public Int32 Credits { get; set; }
        public String Title { get; set; }
    }

    #endregion
}
