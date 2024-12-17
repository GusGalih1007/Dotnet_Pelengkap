using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Studentjoin;
using Pelengkap.Model;

namespace Pelengkap.Mapper
{
    public static class StudentMapper
    {
        public static StudentjoinDto ToStudentDto(this Student studentModel)
        {
            return new StudentjoinDto
            {
                Id = studentModel.Id,
                Firstname = studentModel.Firstname,
                Lastname = studentModel.Lastname,
                DepartmentId = studentModel.DepartmentId
            };
        }

        public static Student CreateStudentDto(this CreateStudentsJoin studentDto)
        {
            return new Student
            {
                Firstname = studentDto.Firstname,
                Lastname = studentDto.Lastname,
                DepartmentId = studentDto.DepartmentId
            };
        }

        public static Student UpdateStudentDto(this UpdateStudentDto studentDto)
        {
            return new Student
            {
                Firstname = studentDto.Firstname,
                Lastname = studentDto.Lastname,
                DepartmentId = studentDto.DepartmentId
            };
        }
    }
}