﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Interfaces;
using Main.Domain.Models.Faq;
using Main.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Main.Domain.Repositories
{
    public class FaqRepository : IFaqRepository
    {

        private readonly EshopContext db; 
        public FaqRepository(EshopContext context)
        {
            db = context;
        }

        public bool Create(Faq aq)
        {
            db.Faqs.Add(aq);
            return true;
        }

        public List<Faq> GetAllQuestions()
        {
            return db.Faqs.Where(q =>  !q.IsDelete).ToList();
        }

        public Faq GetQuestionById(int id)
        {
          return  db.Faqs.FirstOrDefault(q=>q.Id ==id);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Faq aq)
        {
            db.Faqs.Update(aq);
         
        }
    }
}