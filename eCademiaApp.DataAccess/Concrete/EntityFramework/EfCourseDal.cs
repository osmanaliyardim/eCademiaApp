﻿using Core.DataAccess.EntityFramework;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.DataAccess.Concrete.EntityFramework;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, eCademiaAppContext>, ICourseDal
    {
        public List<CourseDetailDto> GetCourseDetails(Expression<Func<CourseDetailDto, bool>> filter = null)
        {
            using (var context = new eCademiaAppContext())
            {
                var result = from c in context.Courses
                             join t in context.CourseTypes
                                 on c.TypeId equals t.Id
                             join m in context.CourseImages
                                 on c.Id equals m.CourseId
                             join i in context.Instructors
                                on c.InstructorId equals i.Id
                             select new CourseDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Instructor = i.Name,
                                 Type = t.Name,
                                 ImagePath = m.ImagePath,
                                 Price = c.Price,
                                 SalePrice = c.SalePrice,
                                 Point = c.Point
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
