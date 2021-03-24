using PeopleSharp.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace PeopleSharp.Server.DataAccess
{
    public class DaoDepartments
    {
        public IEnumerable<Department> GetAllDepartments()
        {
            DataTable dtAllDepartments = GetAllDepartmentsFromDB();

            if (dtAllDepartments != null)
            {
                List<Department> listAllDepartments = new();

                for (int i = 0; i <= dtAllDepartments.Rows.Count; i++)
                {
                    var (departmentName, subdepartments, employeesDirectlyInDepartment, headOfDepartment) = Parse(dtAllDepartments.Rows[i]);

                    Department department = new Department(departmentName, subdepartments, employeesDirectlyInDepartment, headOfDepartment);

                    listAllDepartments.Add(department);
                }

                return listAllDepartments;
            }
            else
            {
                return new List<Department>();
            }
        }

        private Manager ParseManager(DataRow row)
        {
            if (row == null)
                return null;

            return new Manager()
            {
                FirstName = SafeGetColumnValueString(ColumnNames.FirstName, row),
                LastName = SafeGetColumnValueString(ColumnNames.LastName, row),
                JobTitle = SafeGetColumnValueString(ColumnNames.JobTitle, row),
            };
        }

        private (string departmentName, List<Department>? subdepartments, List<Employee>? employeesDirectlyInDepartment, Manager headOfDepartment) Parse(DataRow row)
        {
            if (row == null)
                return (null, null, null, null);

            // Mock data
            if (currentMockData > 2)
                currentMockData = 0;

            switch (currentMockData)
            {
                case 0:
                    {
                        Manager managerJohnDoe = new Manager
                        {
                            FirstName = "John",
                            LastName = "Doe"
                        };
                        currentMockData++;
                        return ("IoT", null, null, managerJohnDoe);
                    }
                case 1:
                    {
                        Manager managerJaneDoe = new Manager()
                        {
                            FirstName = "Jane",
                            LastName = "Doe"
                        };
                        currentMockData++;
                        return ("QA", null, null, managerJaneDoe);
                    }
                case 2:
                    {
                        Manager managerJakeSmith = new Manager()
                        {
                            FirstName = "Jake",
                            LastName = "Smith"
                        };
                        currentMockData++;
                        return ("RnD", null, null, managerJakeSmith);
                    }
                default:
                    {
                        currentMockData = 0;
                        return ("Department", null, null, null);
                    }
            };
        }
        static int currentMockData = 0;

        private string SafeGetColumnValueString(string columnName, DataRow row)
        {
            if (string.IsNullOrWhiteSpace(columnName) || row == null || !row.Table.Columns.Contains(columnName) || row.IsNull(columnName))
                return null;

            return (string)row[columnName];
        }

        private struct ColumnNames
        {
            public static string FirstName => "FirstName";
            public static string LastName => "LastName";
            public static string JobTitle => "JobTitle";
            public static string DepartmentName => "DepartmentName";
        }

        public DataTable GetAllDepartmentsFromDB()
        {
            // todo Implement
            DataTable dtMockData = new DataTable("Departments");

            DataColumn idColumn = new();
            idColumn.DataType = typeof(int);
            idColumn.ColumnName = "Id";
            idColumn.AutoIncrement = true;
            dtMockData.Columns.Add(idColumn);

            DataColumn departmentNameColumn = new();
            departmentNameColumn.DataType = typeof(string);
            departmentNameColumn.ColumnName = "DepartmentName";
            departmentNameColumn.DefaultValue = DBNull.Value;
            dtMockData.Columns.Add(departmentNameColumn);

            DataColumn parentDepartmentIdColumn = new();
            parentDepartmentIdColumn.DataType = typeof(int);
            parentDepartmentIdColumn.ColumnName = "ParentDepartment_Id";
            parentDepartmentIdColumn.AutoIncrement = true;
            dtMockData.Columns.Add(parentDepartmentIdColumn);

            DataRow mockedDataRowRnD = dtMockData.NewRow();
            mockedDataRowRnD["Id"] = 1;
            mockedDataRowRnD["DepartmentName"] = "RnD";
            mockedDataRowRnD["ParentDepartment_Id"] = DBNull.Value;
            dtMockData.Rows.Add(mockedDataRowRnD);

            DataRow mockedDataRowIoT = dtMockData.NewRow();
            mockedDataRowRnD["Id"] = 2;
            mockedDataRowIoT["DepartmentName"] = "IoT";
            mockedDataRowRnD["ParentDepartment_Id"] = 1;
            dtMockData.Rows.Add(mockedDataRowIoT);

            DataRow mockedDataRowQA = dtMockData.NewRow();
            mockedDataRowRnD["Id"] = 3;
            mockedDataRowIoT["DepartmentName"] = "QA";
            mockedDataRowRnD["ParentDepartment_Id"] = 1;
            dtMockData.Rows.Add(mockedDataRowQA);

            return dtMockData;
        }
    }
}
