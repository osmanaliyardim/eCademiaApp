﻿using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.Constants;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public IResult Add(Course course)
        {
            _courseDal.Add(course);

            return new SuccessResult(Messages.CourseAdded);
        }

        public IResult Delete(Course course)
        {
            _courseDal.Delete(course);

            return new SuccessResult(Messages.CourseDeleted);
        }

        public IDataResult<List<Course>> GetAll()
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll());
        }

        public IDataResult<Course> GetById(int id)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails());
        }

        public IDataResult<List<Course>> GetCoursesByInstructorId(int instructorId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(i => i.InstructorId == instructorId));
        }

        public IDataResult<List<Course>> GetCoursesByTypeId(int typeId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(i => i.TypeId == typeId));
        }

        public IResult Update(Course course)
        {
            _courseDal.Update(course);

            return new SuccessResult(Messages.CourseUpdated);
        }
    }
}