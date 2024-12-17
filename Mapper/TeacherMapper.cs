using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Teacherjoin;
using Pelengkap.Model;

namespace Pelengkap.Mapper
{
    public static class TeacherMapper
    {
        public static TeacherjoinDto ToTeacherDto(this Teacher teacherModel)
        {
            return new TeacherjoinDto
            {
                Id = teacherModel.Id,
                First = teacherModel.First,
                Last = teacherModel.Last,
                City = teacherModel.City
            };
        }

        public static Teacher CreateTeacherDto(this CreateTeacherFDto teacherFDto)
        {
            return new Teacher
            {
                First = teacherFDto.First,
                Last = teacherFDto.Last,
                City = teacherFDto.City
            };
        }

        public static Teacher UpdateTeacherDto(this UpdateTeacherDto teacherFDto)
        {
            return new Teacher
            {
                First = teacherFDto.First,
                Last = teacherFDto.Last,
                City = teacherFDto.City
            };
        }
    }
}