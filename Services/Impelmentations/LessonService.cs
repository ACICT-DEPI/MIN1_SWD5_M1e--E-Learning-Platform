using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Lesson;
using Enities.ViweModel.Progress;
using Entites.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
    public sealed class LessonService : ILessonService
    {
        private readonly IRepositoryManger _repositoryManger;
        
        private readonly IMapper _mapper;

        public LessonService(IRepositoryManger repositoryManger,IMapper mapper)
        {
            
            _repositoryManger = repositoryManger;
            _mapper = mapper;
        }
        public  async Task<List<GetLessonVM>> GetLessons(int moduleid)
        {
            try
            {
                
                var lessones =await  _repositoryManger.lessonRepository.GetAllLessonByMOduleId(moduleid);
                var lessondto = _mapper.Map<List<GetLessonVM>>(lessones);
                foreach (var lesson in lessondto) {
                    var repo = await _repositoryManger.progressRepository.GetProgress("new-id", lesson.Id);

					var checkedlesson = _mapper.Map<List<GetProgressVM>>(repo);

                    if (checkedlesson != null && checkedlesson.Count()>0)
                    {  
                        lesson.IsChecked = true;  
                    }
                   
				}
                return lessondto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occure While Get Lessons");
            }

        }
        public async Task<ResponseVM> CreateLesson(CreateorUpdateLessonVM model,int moduleid)
        {
            var lesson= _mapper.Map<Lesson>(model);
            lesson.ModuleId = moduleid;
            var result= await _repositoryManger.lessonRepository.CreateNewLesson(lesson);
            if (result.isSuccess)
            {
                try
                {
                    await _repositoryManger.Save();
                }
                catch (Exception ex)
                {
                    result.message += ex.Message.ToString();
                }
            }
            return result;
        }

        public async Task<ResponseVM> UpdateLesson(CreateorUpdateLessonVM model, int id)
        {
            var lesson = await _repositoryManger.lessonRepository.GetLessonById(id, false);
            if (lesson == null)
                return new ResponseVM { isSuccess = false, message = "No Found Lesson with this id" };
            var updatedlesson = _mapper.Map<Lesson>(model);
            updatedlesson.Id = lesson.Id;
            updatedlesson.ModuleId = lesson.ModuleId;
            var result = await _repositoryManger.lessonRepository.UpdateLesson(updatedlesson);
            if (result.isSuccess)
            {
                try
                {
                    await _repositoryManger.Save();

                }
                catch (Exception ex)
                {
                    result.message += ex.Message;
                }
            }
            return result;
        }

        public async Task<ResponseVM> DeleteLesson(int id)
        {
            var lesson = await _repositoryManger.lessonRepository.GetLessonById(id, true);
            if (lesson == null)
                return new ResponseVM { isSuccess = false, message = "No Found Lesson with this id" };
            lesson.IsDeleted = true;

            //var result = await _repositoryManger.lessonRepository.DeleteLesson(lesson);
            //if (result.isSuccess)
            //{
                try
                {
                    await _repositoryManger.Save();
                return new ResponseVM { isSuccess = true, message = "the process of Felete is Sucess" };

            }
            catch (Exception ex)
                {
                return new ResponseVM { isSuccess = false, message = ex.Message.ToString() };

                //result.message += ex.Message;
            }
            //}
            //return result;
        }
    }
}
