using System;

namespace API.DTOs
{
    public class PermissionDTO
    {
        public int? Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public string PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
