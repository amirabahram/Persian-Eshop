using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.Faq;
using Main.Domain.Repositories;
using Main.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class FaqService : IFaqService
    {
        private IFaqRepository _faqRepo;

        public FaqService(IFaqRepository faqRepo)//this is relatet to IoC
        {
            _faqRepo = faqRepo;
        }

        public bool CreateFaq(CreateFaqViewModel aq)
        {
            
            if (aq == null)
            {
                return false;
            }
            
            var newFaq = new Faq()
            {
                Question = aq.Question,
                Answer = aq.Answer,
                CreateDate = DateTime.Now
            };
            _faqRepo.Create(newFaq);
            _faqRepo.SaveChanges();
            return true;
        }

        public bool DeleteFaq(int id)
        {
            var faq = _faqRepo.GetQuestionById(id);
            if (faq == null) return false;
            faq.IsDelete = true;
            _faqRepo.Update(faq);
            _faqRepo.SaveChanges();
            return true;
            
        }

        public List<Faq> GetAllQuestions()
        {
           return _faqRepo.GetAllQuestions();

        }

        public UpdateFaqViewModel GetQuestionForEdit(int id)
        {
            
            var faq = _faqRepo.GetQuestionById(id);
            return  new UpdateFaqViewModel
            {
                Question = faq.Question,
                Answer = faq.Answer,
                Id = id
            };
        }

        public UpdateFaqViewModel ShowFaqForEditById(int id)
        {
            var faq = _faqRepo.GetFaqById(id);
            if(faq == null)
            {
                return null;
            }
            else
            {
                var UpdNew = new UpdateFaqViewModel();
                UpdNew.Id = faq.Id;
                UpdNew.Question = faq.Question;
                UpdNew.Answer = faq.Answer;
                return UpdNew;
            }
        }

        public UpdateFaqResult UpdateFaq(UpdateFaqViewModel aq)
        {
            var faq = _faqRepo.GetQuestionById(aq.Id);
            if (faq == null) return UpdateFaqResult.FaqNotFound;
            //if (_faqRepo.DuplicatedQuestion(faq.Question))
            //    return UpdateFaqResult.DuplicatedQuestion;
            faq.Answer = aq.Answer;
            faq.Question = aq.Question;
            _faqRepo.Update(faq);
            _faqRepo.SaveChanges();
            return UpdateFaqResult.Success;

        }
    }
}
